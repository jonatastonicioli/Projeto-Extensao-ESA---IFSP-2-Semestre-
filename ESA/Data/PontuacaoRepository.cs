using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Data;

/// <summary>Acesso às pontuações das peças (RF-04, RF-05).</summary>
public class PontuacaoRepository
{
    public void Inserir(Pontuacao p)
    {
        using var conn = Database.Abrir();

        using (var cont = new MySqlCommand("SELECT COUNT(*) FROM pontuacoes WHERE aluno_id = @id", conn))
        {
            cont.Parameters.AddWithValue("@id", p.AlunoId);
            long qtd = Convert.ToInt64(cont.ExecuteScalar());
            if (qtd >= Pontuacao.MaxPecasPorAluno)
                throw new RegraNegocioException(
                    $"Limite de {Pontuacao.MaxPecasPorAluno} peças atingido para este aluno.");
        }

        using var cmd = new MySqlCommand(
            "INSERT INTO pontuacoes (aluno_id, valor, data_registro) VALUES (@aluno, @valor, @data)", conn);
        cmd.Parameters.AddWithValue("@aluno", p.AlunoId);
        cmd.Parameters.AddWithValue("@valor", p.Valor);
        cmd.Parameters.AddWithValue("@data", p.DataRegistro);
        cmd.ExecuteNonQuery();
        p.Id = (int)cmd.LastInsertedId;
    }

    public void Atualizar(Pontuacao p)
    {
        using var conn = Database.Abrir();
        using var cmd = new MySqlCommand("UPDATE pontuacoes SET valor = @valor WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("@valor", p.Valor);
        cmd.Parameters.AddWithValue("@id", p.Id);
        if (cmd.ExecuteNonQuery() == 0)
            throw new RegraNegocioException("Pontuação não encontrada.");
    }

    public void Remover(int id)
    {
        using var conn = Database.Abrir();
        using var cmd = new MySqlCommand("DELETE FROM pontuacoes WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    /// <summary>Pontuações do aluno na ordem em que foram registradas.</summary>
    public List<Pontuacao> ListarPorAluno(int alunoId)
    {
        var lista = new List<Pontuacao>();
        using var conn = Database.Abrir();
        using var cmd = new MySqlCommand(
            "SELECT id, aluno_id, valor, data_registro FROM pontuacoes WHERE aluno_id = @id ORDER BY data_registro, id",
            conn);
        cmd.Parameters.AddWithValue("@id", alunoId);
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            lista.Add(new Pontuacao(
                rd.GetInt32("id"),
                rd.GetInt32("aluno_id"),
                Convert.ToDouble(rd["valor"]),
                rd.GetDateTime("data_registro")));
        }
        return lista;
    }
}
