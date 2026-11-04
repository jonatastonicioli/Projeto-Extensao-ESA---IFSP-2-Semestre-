using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Data;

/// <summary>CRUD de alunos (RF-01, RF-02, RF-03) usando ADO.NET.</summary>
public class AlunoRepository
{
    public void Inserir(Aluno aluno)
    {
        using var conn = Database.Abrir();

        // RF-01: limite de 50 alunos
        using (var cont = new MySqlCommand("SELECT COUNT(*) FROM alunos", conn))
        {
            long total = Convert.ToInt64(cont.ExecuteScalar());
            if (total >= Aluno.MaxAlunos)
                throw new RegraNegocioException($"Limite de {Aluno.MaxAlunos} alunos atingido.");
        }

        if (ExisteNome(conn, aluno.Nome, 0))
            throw new RegraNegocioException($"O aluno '{aluno.Nome}' já está cadastrado.");

        using var cmd = new MySqlCommand("INSERT INTO alunos (nome) VALUES (@nome)", conn);
        cmd.Parameters.AddWithValue("@nome", aluno.Nome);
        cmd.ExecuteNonQuery();
        aluno.Id = (int)cmd.LastInsertedId;
    }

    public void Atualizar(Aluno aluno)
    {
        using var conn = Database.Abrir();

        if (ExisteNome(conn, aluno.Nome, aluno.Id))
            throw new RegraNegocioException($"Já existe outro aluno chamado '{aluno.Nome}'.");

        using var cmd = new MySqlCommand("UPDATE alunos SET nome = @nome WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("@nome", aluno.Nome);
        cmd.Parameters.AddWithValue("@id", aluno.Id);
        if (cmd.ExecuteNonQuery() == 0)
            throw new RegraNegocioException($"Aluno com ID {aluno.Id} não encontrado.");
    }

    /// <summary>Remove o aluno e (por ON DELETE CASCADE) todo o seu histórico de pontuações.</summary>
    public void Remover(int id)
    {
        using var conn = Database.Abrir();
        using var cmd = new MySqlCommand("DELETE FROM alunos WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        if (cmd.ExecuteNonQuery() == 0)
            throw new RegraNegocioException($"Aluno com ID {id} não encontrado.");
    }

    public List<Aluno> Listar()
    {
        var lista = new List<Aluno>();
        using var conn = Database.Abrir();
        const string sql = @"SELECT a.id, a.nome, COUNT(p.id) AS qtd
                             FROM alunos a LEFT JOIN pontuacoes p ON p.aluno_id = a.id
                             GROUP BY a.id, a.nome ORDER BY a.id";
        using var cmd = new MySqlCommand(sql, conn);
        using var rd = cmd.ExecuteReader();
        while (rd.Read())
            lista.Add(new Aluno(rd.GetInt32("id"), rd.GetString("nome"), Convert.ToInt32(rd["qtd"])));
        return lista;
    }

    public Aluno? BuscarPorId(int id)
    {
        foreach (Aluno a in Listar())
            if (a.Id == id) return a;
        return null;
    }

    private static bool ExisteNome(MySqlConnection conn, string nome, int idIgnorado)
    {
        using var cmd = new MySqlCommand(
            "SELECT COUNT(*) FROM alunos WHERE nome = @nome AND id <> @id", conn);
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@id", idIgnorado);
        return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
    }
}
