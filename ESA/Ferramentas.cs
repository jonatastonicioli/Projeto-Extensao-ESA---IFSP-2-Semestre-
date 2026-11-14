using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA
{
    public class Ferramentas
    {
        // Exibe uma mensagem de erro e marca o textbox com a cor vermelha
        public static void mostraErroTextBox(TextBox txb, string message)
        {
            Color cor = txb.BackColor;   // guarda a cor original de fundo do textbox
            txb.BackColor = Color.Red;   // seta a cor de fundo para vermelha

            // exibe uma mensagem de erro
            MessageBox.Show(message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // volta o textbox para a cor original
            txb.BackColor = cor;

            // coloca o foco do cursor no textbox
            txb.Focus();
        }

        // Exibe uma mensagem de erro simples (sem textbox)
        public static void mostraErro(string message)
        {
            MessageBox.Show(message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Exibe uma mensagem de aviso/informação
        public static void mostraAviso(string message)
        {
            MessageBox.Show(message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Pergunta Sim/Não ao usuário
        public static bool confirma(string message)
        {
            return MessageBox.Show(message, "ESA", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // Trata as exceções mais comuns das janelas e mostra uma mensagem clara ao usuário
        public static void tratarExcecao(Exception ex)
        {
            if (ex is RegraNegocioException)        // regra de negócio violada (lançada com throw)
                mostraAviso(ex.Message);
            else if (ex is FormatException)         // exceção da biblioteca (ex.: Parse)
                mostraErro("Valor inválido. Confira os campos numéricos e de data.");
            else if (ex is MySqlException)          // erro do banco de dados
                mostraErro("Erro de banco de dados: " + ex.Message);
            else
                mostraErro("Erro inesperado: " + ex.Message);
        }

        // Configura uma tabela (DataGridView) como somente leitura, linha inteira selecionável
        public static void configuraGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = SystemColors.Window;
        }
    }
}
