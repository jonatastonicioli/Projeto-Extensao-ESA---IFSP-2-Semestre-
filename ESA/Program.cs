using ESA.Data;
using ESA.Forms;

namespace ESA;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            Database.TestarConexao();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Não foi possível conectar ao MySQL.\n\n" + ex.Message +
                "\n\nVerifique se o MySQL está rodando, se o script Database/schema.sql foi executado e a string de conexão (variável de ambiente ESA_MYSQL_CONN).",
                "ESA - Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Os repositórios são criados uma única vez e compartilhados (por referência) entre as janelas.
        var alunos = new AlunoRepository();
        var pontuacoes = new PontuacaoRepository();

        Application.Run(new FormPrincipal(alunos, pontuacoes));
    }
}
