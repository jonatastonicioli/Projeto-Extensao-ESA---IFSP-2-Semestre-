using System.Data;
using ESA.Models;

namespace ESA.Forms;

/// <summary>RF-08: ranking dos competidores de uma modalidade em uma edição.</summary>
public partial class FormRanking : Form
{
    private Cadastro cadastro;

    public FormRanking(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void FormRanking_Load(object? sender, EventArgs e)
    {
        try
        {
            cmbModalidade.DataSource = cadastro.listarModalidades();
            cmbEdicao.DataSource = cadastro.listarEdicoes();
            gerar(false);
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
        Item? modalidade = cmbModalidade.SelectedItem as Item;
        Item? edicao = cmbEdicao.SelectedItem as Item;
        if (modalidade == null || edicao == null) return;

        // uma tabela nova a cada vez (o método gerarRanking acrescenta a coluna "Pos")
        DataTable ranking = new DataTable();
        cadastro.gerarRanking(ranking, modalidade.getId(), edicao.getId());
        dgvRanking.DataSource = ranking;

        if (avisar && ranking.Rows.Count == 0)
            Ferramentas.mostraAviso("Nenhum competidor inscrito nesta modalidade e edição.");
    }
}
