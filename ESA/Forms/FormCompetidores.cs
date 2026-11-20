using System.Data;
using ESA.Models;

namespace ESA.Forms;

/// <summary>RF-01, RF-02 e RF-03: cadastrar, listar e remover competidores.</summary>
public partial class FormCompetidores : Form
{
    private Cadastro cadastro;
    private DataTable tabela = new DataTable();

    public FormCompetidores(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void FormCompetidores_Load(object? sender, EventArgs e)  //Quando a tela é inicializada isso acontece:
    {
        try
        {
            cmbInstituicao.DataSource = cadastro.listarInstituicoes(); //Preenche os combo box
            carregarGrid(); //atualiza o DataGrid
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void carregarGrid() //mostrar inicial ou atualizar os dados do DataGridView (Usado no FormCompetidores e FormInscricoes)
    {
        cadastro.gerarRelatorioCompetidores(tabela);
        dgvCompetidores.DataSource = tabela;
        dgvCompetidores.ClearSelection();

        lblTotal.Text = tabela.Rows.Count == 0
            ? "Nenhum competidor cadastrado"
            : tabela.Rows.Count + "/" + Competidor.MaxCompetidores + " competidores cadastrados";
    }

    // ID do competidor selecionado na tabela (ou -1 se não houver)
    private int idSelecionado()
    {
        if (dgvCompetidores.CurrentRow == null) return -1;
        return Convert.ToInt32(dgvCompetidores.CurrentRow.Cells["ID"].Value);
    }

    private void limparCampos()
    {
        txtNome.Clear();
        txtEmail.Clear();
        txtTelefone.Clear();
        if (cmbInstituicao.Items.Count > 0) cmbInstituicao.SelectedIndex = 0;
        txtNome.Focus();
    }

    private int idInstituicaoEscolhida()
    {
        Item? inst = cmbInstituicao.SelectedItem as Item;
        return inst == null ? 0 : inst.getId();
    }

    private void btnCadastrar_Click(object? sender, EventArgs e)
    {
        try
        {
            // o construtor valida os dados (lança RegraNegocioException se algo estiver errado)
            Competidor c = new Competidor(txtNome.Text, txtEmail.Text, idInstituicaoEscolhida(), txtTelefone.Text);
            cadastro.inserirCompetidor(c);

            limparCampos();
            carregarGrid(); //atualiza o grid depois do cadastro "DPS DE APERTAR O BOTAO"
            Ferramentas.mostraAviso("Competidor '" + c.getNome() + "' cadastrado com ID " + c.getId() + ".");
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void btnRemover_Click(object? sender, EventArgs e)
    {
        int id = idSelecionado();
        if (id < 0)
        {
            Ferramentas.mostraAviso("Selecione um competidor na tabela.");
            return;
        }

        string nome = dgvCompetidores.CurrentRow?.Cells["Nome"].Value?.ToString() ?? "";
        if (!Ferramentas.confirma("Remover '" + nome + "'?\nSuas inscrições e notas também serão apagadas."))
            return;

        try
        {
            cadastro.removerCompetidor(id);
            limparCampos();
            carregarGrid();
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void btnLimpar_Click(object? sender, EventArgs e)
    {
        limparCampos();
        dgvCompetidores.CurrentCell = null;
        dgvCompetidores.ClearSelection();
    }
}
