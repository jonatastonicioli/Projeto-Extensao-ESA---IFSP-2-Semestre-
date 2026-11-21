using System.Data;
using System.Globalization;
using ESA.Models;

namespace ESA.Forms;

/// <summary>RF-04, RF-05, RF-06 e RF-07: lançar notas, ver o histórico e as métricas da inscrição.</summary>
public partial class FormNotas : Form
{
    private Cadastro cadastro; //referencia para o objeto cadastro criado no program.cs
    private DataTable tabela = new DataTable(); //objeto tabela criado para atualizar o grid na funcao carregarGrid()

    public FormNotas(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void FormNotas_Load(object? sender, EventArgs e) // Quando a tela é inicializa isso acontece
    {
        try
        {
            cmbAvaliador.DataSource = cadastro.listarAvaliadores(); //Combobox Preenchido
            cmbInscricao.DataSource = cadastro.listarInscricoes();  //Combobox Preenchido
            carregarInscricao();
            if (cmbInscricao.Items.Count == 0)
                Ferramentas.mostraAviso("Nenhuma inscrição cadastrada. Faça uma inscrição primeiro.");
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void cmbInscricao_SelectedIndexChanged(object? sender, EventArgs e)
    {
        try { carregarInscricao(); }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    // carrega os critérios da prova e as notas da inscrição escolhida
    private void carregarInscricao()
    {
        Item? inscricao = cmbInscricao.SelectedItem as Item; //Lê qual inscricao esta selecionada no comboBox
        if (inscricao == null) //Se nao existir incricao (ainda não existe inscrição cadastrada)
        {
            tabela.Clear(); // Limpa a tabela de notas e o texto da média, e sai.
            lblMedia.Text = "";
            return;
        }

        carregarNotas(); //Se existe incricao busca as notas dessa inscrição no banco, mostra no grid e recalcula a média, a maior e a menor nota.
    }

    private void carregarNotas()
    {
        Item? inscricao = cmbInscricao.SelectedItem as Item;
        if (inscricao == null) return;

        cadastro.gerarRelatorioNotas(tabela, inscricao.getId());
        dgvNotas.DataSource = tabela;
        atualizarMetricas();
    }

    // RF-06: média, maior e menor nota da inscrição
    private void atualizarMetricas()
    {
        if (tabela.Rows.Count == 0)
        {
            lblMedia.Text = "Nenhuma nota lançada";
            return;
        }

        double soma = 0;
        double maior = double.MinValue;
        double menor = double.MaxValue;

        foreach (DataRow linha in tabela.Rows)
        {
            double valor = Convert.ToDouble(linha["Nota"]);
            soma += valor;
            if (valor > maior) maior = valor;
            if (valor < menor) menor = valor;
        }

        lblMedia.Text = "Média: " + (soma / tabela.Rows.Count).ToString("0.00") +
                        " | Maior: " + maior.ToString("0.00") +
                        " | Menor: " + menor.ToString("0.00");
    }

    private void btnLancar_Click(object? sender, EventArgs e)
    {
        try
        {
            Item? inscricao = cmbInscricao.SelectedItem as Item;
            Item? avaliador = cmbAvaliador.SelectedItem as Item;

            if (inscricao == null || avaliador == null)
                throw new RegraNegocioException("Selecione a inscrição e o avaliador.");

            // Parse lança FormatException se o texto não for um número
            double valor;
            try
            {
                valor = double.Parse(txtNota.Text.Trim(), CultureInfo.GetCultureInfo("pt-BR"));
            }
            catch (FormatException)
            {
                Ferramentas.mostraErroTextBox(txtNota, "Nota inválida. Digite um número, por exemplo 85,5.");
                return;
            }

            Nota nota = new Nota(inscricao.getId(), avaliador.getId(), valor); //Vai para o models/nota.cs fazer as validações
            cadastro.lancarNota(nota);

            txtNota.Clear();
            carregarNotas(); //atualiza o grid depois do notas "DPS DE APERTAR O BOTAO"
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void btnRemover_Click(object? sender, EventArgs e)
    {
        if (dgvNotas.CurrentRow == null)
        {
            Ferramentas.mostraAviso("Selecione uma nota na tabela.");
            return;
        }

        if (!Ferramentas.confirma("Remover a nota selecionada?")) return;

        try
        {
            int id = Convert.ToInt32(dgvNotas.CurrentRow.Cells["Cód."].Value);
            cadastro.removerNota(id);
            carregarNotas(); //atualiza o grid depois do notas "DPS DE APERTAR O BOTAO"
        } 
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }
}
