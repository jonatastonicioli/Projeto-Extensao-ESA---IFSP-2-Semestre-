using ESA.Forms;

namespace ESA;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Um único objeto Cadastro (todo o acesso ao banco) é criado aqui e
        // compartilhado, por referência, com todas as janelas.
        Cadastro cadastro = new Cadastro();

        try
        {
            cadastro.testarConexao();
        }
        catch (Exception ex)
        {
            Ferramentas.mostraErro("Não foi possível acessar o banco de dados.\n\n" + ex.Message +
                "\n\nConfira se o MySQL está ligado, se o script Database/schema.sql já foi executado " +
                "e se a senha (pwd) em Cadastro.cs é a do seu MySQL.");
            return;
        }

        Application.Run(new FormPrincipal(cadastro));
    }
}
