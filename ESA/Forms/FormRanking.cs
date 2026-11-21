using System.Data;
using ESA.Models;

namespace ESA.Forms;

/// <summary>RF-08: ranking dos competidores de uma modalidade em uma edição.</summary>
public partial class FormRanking : Form
{
    private Cadastro cadastro; //referencia para o objeto cadastro criado no program.cs

    public FormRanking(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void FormRanking_Load(object? sender, EventArgs e) // Quando a tela é inicializa isso acontece
    {
        try
        {
            cmbModalidade.DataSource = cadastro.listarModalidades(); //ComboBoxPreenchido
            cmbEdicao.DataSource = cadastro.listarEdicoes(); //ComboBoxPreenchido
            gerar(false); //Gera o ranking automaticamente ao entrar na tela
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void btnGerar_Click(object? sender, EventArgs e)
    {
        try { gerar(true); }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void gerar(bool avisar)
    {
        Item? modalidade = cmbModalidade.SelectedItem as Item; //Le a modalidade escolhida no combobox
        Item? edicao = cmbEdicao.SelectedItem as Item; // Le a edicao escolhida no comboboz
        if (modalidade == null || edicao == null) return;

        //Pede ao Cadastro o ranking dessa combinação e mostra no grid.
        DataTable ranking = new DataTable();
        cadastro.gerarRanking(ranking, modalidade.getId(), edicao.getId());
        dgvRanking.DataSource = ranking;

        if (avisar && ranking.Rows.Count == 0)
            Ferramentas.mostraAviso("Nenhum competidor inscrito nesta modalidade e edição.");
    }
}
