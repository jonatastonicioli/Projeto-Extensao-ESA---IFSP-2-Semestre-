using System.Data;
using ESA.Models;

namespace ESA.Forms;

/// <summary>Inscrição de competidores em uma modalidade de uma edição.</summary>
public partial class FormInscricoes : Form
{
    private Cadastro cadastro;
    private DataTable tabela = new DataTable();

    public FormInscricoes(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void FormInscricoes_Load(object? sender, EventArgs e)
    {
        try
        {
            cmbCompetidor.DataSource = cadastro.listarCompetidores();
            cmbModalidade.DataSource = cadastro.listarModalidades();
            cmbEdicao.DataSource = cadastro.listarEdicoes();
            carregarGrid();
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void carregarGrid()
    {
        cadastro.gerarRelatorioInscricoes(tabela);
        dgvInscricoes.DataSource = tabela;
    }

    private int idSelecionado()
    {
        if (dgvInscricoes.CurrentRow == null) return -1;
        return Convert.ToInt32(dgvInscricoes.CurrentRow.Cells["ID"].Value);
    }

    private static int idDoItem(object? selecionado)
    {
        Item? item = selecionado as Item;
        return item == null ? 0 : item.getId();
    }

    private void btnInscrever_Click(object? sender, EventArgs e)
    {
        try
        {
            Inscricao inscricao = new Inscricao(idDoItem(cmbCompetidor.SelectedItem),
                                                idDoItem(cmbModalidade.SelectedItem),
                                                idDoItem(cmbEdicao.SelectedItem));

            cadastro.inserirInscricao(inscricao);
            carregarGrid();
            Ferramentas.mostraAviso("Inscrição realizada com sucesso.");
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void btnRemover_Click(object? sender, EventArgs e)
    {
        int id = idSelecionado();
        if (id < 0)
        {
            Ferramentas.mostraAviso("Selecione uma inscrição na tabela.");
            return;
        }

        if (!Ferramentas.confirma("Remover a inscrição selecionada?\nAs notas dela também serão apagadas."))
            return;

        try
        {
            cadastro.removerInscricao(id);
            carregarGrid();
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }
}
