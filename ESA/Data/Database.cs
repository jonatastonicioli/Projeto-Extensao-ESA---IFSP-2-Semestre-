using MySql.Data.MySqlClient;

namespace ESA.Data;

/// <summary>Acesso ao MySQL via ADO.NET.</summary>
public static class Database
{
    private const string NomeBanco = "esa";

    // Pode ser sobrescrita pela variável de ambiente ESA_MYSQL_CONN
    // Exemplo: Server=localhost;Port=3306;Uid=root;Pwd=sua_senha;
    private static string BaseConexao
    {
        get
        {
            string s = Environment.GetEnvironmentVariable("ESA_MYSQL_CONN")
                       ?? "Server=localhost;Port=3306;Uid=root;Pwd=podemiojo;"; //trocar senha para a correta
            return s.EndsWith(";") ? s : s + ";";
        }
    }

    public static MySqlConnection Abrir()
    {
        var conn = new MySqlConnection(BaseConexao + "Database=" + NomeBanco + ";");
        conn.Open();
        return conn;
    }

    /// <summary>
    /// Apenas testa a conexão. O banco e as tabelas são criados pelo script Database/schema.sql.
    /// </summary>
    public static void TestarConexao()
    {
        using var conn = Abrir();
    }
}
