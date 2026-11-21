using System.Data;
using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA
{
    /// <summary>
    /// Única classe que acessa o banco MySQL (provedor MySql.Data / ADO.NET).
    /// As janelas só chamam os métodos daqui.
    /// </summary>
    public class Cadastro
    {
        private const int MaxNotasPorInscricao = 20;   // RF-04

        private string connectionStr;

        //-------------------------------------------------------------------------

        public Cadastro()
        {
            // ajuste a senha (pwd) para a do seu MySQL
            connectionStr = @"server=127.0.0.1;uid=root;pwd=podemiojo;database=esa;ConnectionTimeout=5";
        }

        // Testa a conexão e confere se o script Database/schema.sql já foi executado.
        // Lança MySqlException se o servidor ou o banco não estiverem disponíveis.
        public void testarConexao()
        {
            contar("SELECT COUNT(*) FROM perfil");
        }

        //=========================================================================
        //  MÉTODOS AUXILIARES (abrem a conexão, executam e SEMPRE fecham no finally)
        //=========================================================================

        private MySqlCommand criarComando(MySqlConnection con, string sql, (string, object?)[] ps)
        {
            MySqlCommand cmd = new MySqlCommand();

            //atribui uma conexão ao comando (obrigatório)
            cmd.Connection = con;

            //seta o comando sql que será executado
            cmd.CommandText = sql;

            //seta os parametros que deverão ser passados para a consulta sql
            foreach ((string nome, object? valor) in ps)
                cmd.Parameters.AddWithValue(nome, valor ?? DBNull.Value);

            return cmd;
        }

        // INSERT / UPDATE / DELETE -> retorna o número de linhas afetadas
        private int executar(string sql, params (string, object?)[] ps)
        {
            MySqlConnection? connectionBD = null;
            MySqlCommand? cmd = null;

            try
            {
                connectionBD = new MySqlConnection(connectionStr);
                connectionBD.Open();
                cmd = criarComando(connectionBD, sql, ps);
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connectionBD != null) connectionBD.Close();
            }
        }

        // SELECT que retorna um único valor (COUNT, MAX, etc.)
        private object? valorUnico(string sql, params (string, object?)[] ps)
        {
            MySqlConnection? connectionBD = null;
            MySqlCommand? cmd = null;

            try
            {
                connectionBD = new MySqlConnection(connectionStr);
                connectionBD.Open();
                cmd = criarComando(connectionBD, sql, ps);
                object? r = cmd.ExecuteScalar();
                return r == DBNull.Value ? null : r;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connectionBD != null) connectionBD.Close();
            }
        }

        private long contar(string sql, params (string, object?)[] ps)
        {
            object? r = valorUnico(sql, ps);
            return r == null ? 0 : Convert.ToInt64(r);
        }

        // SELECT que preenche uma DataTable (usada para mostrar nos DataGridView)
        private void preencher(DataTable table, string sql, params (string, object?)[] ps)
        {
            MySqlConnection? connectionBD = null;
            MySqlCommand? cmd = null;

            try
            {
                table.Clear();
                connectionBD = new MySqlConnection(connectionStr);
                connectionBD.Open();
                cmd = criarComando(connectionBD, sql, ps);

                MySqlDataReader reader = cmd.ExecuteReader();

                //passa o datareader para a tabela ser inicializada com os seus dados!
                table.Load(reader);

                //tenho que fechar o reader após o uso !!!
                reader.Close();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connectionBD != null) connectionBD.Close();
            }
        }

        // SELECT id, texto -> lista de Item (usada para preencher ComboBox)
        private List<Item> listarItens(string sql, params (string, object?)[] ps)
        {
            List<Item> lista = new List<Item>();
            MySqlConnection? connectionBD = null;
            MySqlCommand? cmd = null;

            try
            {
                connectionBD = new MySqlConnection(connectionStr);
                connectionBD.Open();
                cmd = criarComando(connectionBD, sql, ps);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(new Item(reader.GetInt32(0), reader.GetString(1)));
                reader.Close();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connectionBD != null) connectionBD.Close();
            }
            return lista;
        }

        //=========================================================================
        //  LISTAS PARA COMBOBOX
        //=========================================================================

        public List<Item> listarInstituicoes() // retorna uma lista de objetos item (armazena id e texto para preencher os combobox)
        {
            return listarItens("SELECT i.id, CONCAT(i.nome, ' - ', c.nome, '/', es.sigla) FROM instituicao i " +
                               "JOIN cidade c ON c.id = i.cidade_id " +
                               "JOIN estado es ON es.id = c.estado_id ORDER BY i.nome");
        }

        public List<Item> listarModalidades() // retorna uma lista de objetos item (armazena id e texto para preencher os combobox)
        {
            return listarItens("SELECT id, nome FROM modalidade ORDER BY nome");
        }

        public List<Item> listarEdicoes() //retorna uma lista de objetos item (armazena id e texto para preencher os combobox)
        {
            return listarItens("SELECT e.id, CONCAT(e.ano, ' - ', f.nome) FROM edicao e " +
                               "JOIN fase f ON f.id = e.fase_id ORDER BY e.ano DESC, e.id");
        }

        public List<Item> listarCompetidores() //retorna uma lista de objetos item (armazena id e texto para preencher os combobox)
        {
            return listarItens("SELECT c.id, u.nome FROM competidor c " +
                               "JOIN usuario u ON u.id = c.usuario_id ORDER BY u.nome");
        }

        public List<Item> listarAvaliadores() //retorna uma lista de objetos item (armazena id e texto para preencher os combobox)
        {
            return listarItens("SELECT a.id, u.nome FROM avaliador a " +
                               "JOIN usuario u ON u.id = a.usuario_id ORDER BY u.nome");
        }

        public List<Item> listarInscricoes() // retorna uma lista de objetos item (armazena id e texto para preencher os combobox)
        {
            return listarItens(
                "SELECT i.id, CONCAT(u.nome, ' | ', m.nome, ' | ', e.ano, ' ', f.nome) " +
                "FROM inscricao i " +
                "JOIN competidor c ON c.id = i.competidor_id " +
                "JOIN usuario u ON u.id = c.usuario_id " +
                "JOIN modalidade m ON m.id = i.modalidade_id " +
                "JOIN edicao e ON e.id = i.edicao_id " +
                "JOIN fase f ON f.id = e.fase_id " +
                "ORDER BY u.nome, e.ano, m.nome");
        }

        //=========================================================================
        //  COMPETIDORES  (tabelas usuario + competidor)
        //=========================================================================

        public void inserirCompetidor(Competidor competidor)
        {
            // RF-01: limite de 50 competidores
            if (contar("SELECT COUNT(*) FROM competidor") >= Competidor.MaxCompetidores)
                throw new RegraNegocioException("Limite de " + Competidor.MaxCompetidores + " competidores atingido.");

            if (contar("SELECT COUNT(*) FROM usuario WHERE email = @email",
                       ("@email", competidor.getEmail())) > 0)
                throw new RegraNegocioException("Já existe um usuário com o e-mail '" + competidor.getEmail() + "'.");

            if (contar("SELECT COUNT(*) FROM instituicao WHERE id = @i", ("@i", competidor.getInstituicaoId())) == 0)
                throw new RegraNegocioException("Instituição não encontrada.");

            MySqlConnection? connectionBD = null;
            MySqlCommand? cmdUsuario = null;
            MySqlCommand? cmdCompetidor = null;
            MySqlCommand? cmdTelefone = null;
            MySqlTransaction? transacao = null;

            try
            {
                connectionBD = new MySqlConnection(connectionStr);
                connectionBD.Open();

                // os dois INSERTs precisam dar certo juntos (transação)
                transacao = connectionBD.BeginTransaction();

                cmdUsuario = criarComando(connectionBD,
                    "INSERT INTO usuario (nome, email, perfil_id) " +
                    "VALUES (@nome, @email, (SELECT id FROM perfil WHERE nome = 'Competidor'))",
                    new (string, object?)[] { ("@nome", competidor.getNome()), ("@email", competidor.getEmail()) });
                cmdUsuario.Transaction = transacao;
                cmdUsuario.ExecuteNonQuery();
                long usuarioId = cmdUsuario.LastInsertedId;

                cmdCompetidor = criarComando(connectionBD,
                    "INSERT INTO competidor (usuario_id, instituicao_id) " +
                    "VALUES (@usuario, @instituicao)",
                    new (string, object?)[] {
                        ("@usuario", usuarioId),
                        ("@instituicao", competidor.getInstituicaoId()) });
                cmdCompetidor.Transaction = transacao;
                cmdCompetidor.ExecuteNonQuery();
                long competidorId = cmdCompetidor.LastInsertedId;

                // o telefone fica em outra tabela (um competidor pode ter vários)
                if (competidor.getTelefone() != "")
                {
                    cmdTelefone = criarComando(connectionBD,
                        "INSERT INTO telefone (competidor_id, numero) VALUES (@c, @n)",
                        new (string, object?)[] { ("@c", competidorId), ("@n", competidor.getTelefone()) });
                    cmdTelefone.Transaction = transacao;
                    cmdTelefone.ExecuteNonQuery();
                }

                transacao.Commit();
                competidor.setId((int)competidorId);
            }
            catch
            {
                if (transacao != null) transacao.Rollback();
                throw;
            }
            finally
            {
                if (cmdUsuario != null) cmdUsuario.Dispose();
                if (cmdCompetidor != null) cmdCompetidor.Dispose();
                if (cmdTelefone != null) cmdTelefone.Dispose();
                if (connectionBD != null) connectionBD.Close();
            }
        }

        // Remove o competidor: apagar o usuário apaga o competidor, as inscrições e as notas (ON DELETE CASCADE).
        public bool removerCompetidor(int id)
        {
            object? usuarioId = valorUnico("SELECT usuario_id FROM competidor WHERE id = @id", ("@id", id));
            if (usuarioId == null) return false;

            return executar("DELETE FROM usuario WHERE id = @u", ("@u", Convert.ToInt32(usuarioId))) != 0;
        }

        public void gerarRelatorioCompetidores(DataTable table)
        {
            preencher(table,
                "SELECT c.id AS 'ID', u.nome AS 'Nome', u.email AS 'E-mail', " +
                "i.nome AS 'Instituição', " +
                "IFNULL((SELECT GROUP_CONCAT(t.numero SEPARATOR ', ') FROM telefone t WHERE t.competidor_id = c.id), '') AS 'Telefone', " +
                "(SELECT COUNT(*) FROM inscricao x WHERE x.competidor_id = c.id) AS 'Inscrições' " +
                "FROM competidor c " +
                "JOIN usuario u ON u.id = c.usuario_id " +
                "JOIN instituicao i ON i.id = c.instituicao_id " +
                "ORDER BY u.nome");
        }

        public long contarCompetidores()
        {
            return contar("SELECT COUNT(*) FROM competidor");
        }

        //=========================================================================
        //  INSCRIÇÕES
        //=========================================================================

        public void inserirInscricao(Inscricao inscricao)
        {
            if (contar("SELECT COUNT(*) FROM competidor WHERE id = @c", ("@c", inscricao.getCompetidorId())) == 0)
                throw new RegraNegocioException("Competidor não encontrado.");

            // a modalidade precisa ter uma prova cadastrada na edição escolhida
            if (contar("SELECT COUNT(*) FROM prova WHERE modalidade_id = @m AND edicao_id = @e",
                       ("@m", inscricao.getModalidadeId()), ("@e", inscricao.getEdicaoId())) == 0)
                throw new RegraNegocioException("Não há prova cadastrada para esta modalidade nesta edição.");

            if (contar("SELECT COUNT(*) FROM inscricao WHERE competidor_id = @c AND modalidade_id = @m AND edicao_id = @e",
                       ("@c", inscricao.getCompetidorId()), ("@m", inscricao.getModalidadeId()),
                       ("@e", inscricao.getEdicaoId())) > 0)
                throw new RegraNegocioException("Este competidor já está inscrito nesta modalidade e edição.");

            executar("INSERT INTO inscricao (competidor_id, modalidade_id, edicao_id, data) " +
                     "VALUES (@c, @m, @e, @data)",
                     ("@c", inscricao.getCompetidorId()), ("@m", inscricao.getModalidadeId()),
                     ("@e", inscricao.getEdicaoId()), ("@data", inscricao.getData()));
        }

        // apaga também as notas da inscrição (ON DELETE CASCADE)
        public bool removerInscricao(int id)
        {
            return executar("DELETE FROM inscricao WHERE id = @id", ("@id", id)) != 0;
        }

        // média simples das notas da inscrição (0 a 100)
        public void gerarRelatorioInscricoes(DataTable table)
        {
            preencher(table,
                "SELECT i.id AS 'ID', u.nome AS 'Competidor', m.nome AS 'Modalidade', " +
                "CONCAT(e.ano, ' - ', f.nome) AS 'Edição', i.data AS 'Data', " +
                "IF(COUNT(n.id) = 0, 'N/A', CAST(ROUND(AVG(n.valor), 2) AS CHAR)) AS 'Média' " +
                "FROM inscricao i " +
                "JOIN competidor c ON c.id = i.competidor_id " +
                "JOIN usuario u ON u.id = c.usuario_id " +
                "JOIN modalidade m ON m.id = i.modalidade_id " +
                "JOIN edicao e ON e.id = i.edicao_id " +
                "JOIN fase f ON f.id = e.fase_id " +
                "LEFT JOIN nota n ON n.inscricao_id = i.id " +
                "GROUP BY i.id, u.nome, m.nome, e.ano, f.nome, i.data " +
                "ORDER BY u.nome, e.ano, m.nome");
        }

        //=========================================================================
        //  NOTAS
        //=========================================================================

        // Lança uma nota (0 a 100) de um avaliador para a inscrição.
        public void lancarNota(Nota nota)
        {
            if (contar("SELECT COUNT(*) FROM inscricao WHERE id = @i", ("@i", nota.getInscricaoId())) == 0)
                throw new RegraNegocioException("Inscrição não encontrada.");

            if (contar("SELECT COUNT(*) FROM avaliador WHERE id = @a", ("@a", nota.getAvaliadorId())) == 0)
                throw new RegraNegocioException("Avaliador não encontrado.");

            // RF-04: no máximo 20 notas por inscrição
            if (contar("SELECT COUNT(*) FROM nota WHERE inscricao_id = @i", ("@i", nota.getInscricaoId())) >= MaxNotasPorInscricao)
                throw new RegraNegocioException("Limite de " + MaxNotasPorInscricao + " notas por inscrição atingido.");

            executar("INSERT INTO nota (inscricao_id, avaliador_id, valor) VALUES (@i, @a, @v)",
                     ("@i", nota.getInscricaoId()), ("@a", nota.getAvaliadorId()), ("@v", nota.getValor()));
        }

        public bool removerNota(int id)
        {
            return executar("DELETE FROM nota WHERE id = @id", ("@id", id)) != 0;
        }

        public void gerarRelatorioNotas(DataTable table, int inscricaoId)
        {
            preencher(table,
                "SELECT n.id AS 'Cód.', u.nome AS 'Avaliador', n.valor AS 'Nota', " +
                "n.data_lancamento AS 'Lançada em' " +
                "FROM nota n " +
                "JOIN avaliador a ON a.id = n.avaliador_id " +
                "JOIN usuario u ON u.id = a.usuario_id " +
                "WHERE n.inscricao_id = @i ORDER BY n.id",
                ("@i", inscricaoId));
        }

        //=========================================================================
        //  RANKING (RF-08)
        //=========================================================================

        public void gerarRanking(DataTable table, int modalidadeId, int edicaoId)
        {
            preencher(table,
                "SELECT u.nome AS 'Competidor', it.nome AS 'Instituição', COUNT(n.id) AS 'Notas', " +
                "IF(COUNT(n.id) = 0, 'N/A', CAST(ROUND(AVG(n.valor), 2) AS CHAR)) AS 'Média', " +
                "IF(COUNT(n.id) = 0, 'N/A', CAST(MAX(n.valor) AS CHAR)) AS 'Maior nota', " +
                "IF(COUNT(n.id) = 0, 'N/A', CAST(MIN(n.valor) AS CHAR)) AS 'Menor nota' " +
                "FROM inscricao i " +
                "JOIN competidor c ON c.id = i.competidor_id " +
                "JOIN usuario u ON u.id = c.usuario_id " +
                "JOIN instituicao it ON it.id = c.instituicao_id " +
                "LEFT JOIN nota n ON n.inscricao_id = i.id " +
                "WHERE i.modalidade_id = @m AND i.edicao_id = @e " +
                "GROUP BY i.id, u.nome, it.nome " +
                // quem não tem notas ("N/A") vai para o final; os demais, da maior para a menor média
                "ORDER BY (COUNT(n.id) = 0), AVG(n.valor) DESC, u.nome",
                ("@m", modalidadeId), ("@e", edicaoId));

            // coluna com a posição no ranking
            table.Columns.Add("Pos", typeof(int)).SetOrdinal(0);
            for (int i = 0; i < table.Rows.Count; i++)
                table.Rows[i]["Pos"] = i + 1;
        }
    }
}
