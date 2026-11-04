using ESA.Data;
using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Forms;

/// <summary>RF-01, RF-02 e RF-03: cadastrar, listar, atualizar e remover alunos.</summary>
public partial class FormAlunos : Form
{
    private readonly AlunoRepository _repo;

    public FormAlunos(AlunoRepository repo)
    {
        InitializeComponent();
        _repo = repo;
    }

    private void FormAlunos_Load(object? sender, EventArgs e) => Recarregar();

    private void Recarregar()
    {
        try
        {
            List<Aluno> lista = _repo.Listar();
            var tabela = new System.Data.DataTable();
            tabela.Columns.Add("ID", typeof(int));
            tabela.Columns.Add("Nome", typeof(string));
            tabela.Columns.Add("Peças", typeof(int));
            foreach (Aluno a in lista) tabela.Rows.Add(a.Id, a.Nome, a.QtdPecas);

            dgvAlunos.DataSource = tabela;
            lblTotal.Text = lista.Count == 0
                ? "Nenhum aluno cadastrado"
                : $"{lista.Count}/{Aluno.MaxAlunos} alunos cadastrados";
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvAlunos_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvAlunos.CurrentRow?.Cells["Nome"].Value is string nome) txtNome.Text = nome;
    }

    private int? IdSelecionado()
    {
        if (dgvAlunos.CurrentRow?.Cells["ID"].Value is int id) return id;
        MessageBox.Show("Selecione um aluno na lista.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private void btnCadastrar_Click(object? sender, EventArgs e)
    {
        try
        {
            var aluno = new Aluno(txtNome.Text);   // valida o nome (throw)
            _repo.Inserir(aluno);
            txtNome.Clear();
            Recarregar();
            MessageBox.Show($"Aluno '{aluno.Nome}' cadastrado com ID {aluno.Id}.", "ESA",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (RegraNegocioException ex)
        {
            MessageBox.Show(ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnAtualizar_Click(object? sender, EventArgs e)
    {
        if (IdSelecionado() is not int id) return;
        try
        {
            var aluno = new Aluno(id, txtNome.Text, 0);
            _repo.Atualizar(aluno);
            Recarregar();
            MessageBox.Show("Nome atualizado com sucesso.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (RegraNegocioException ex)
        {
            MessageBox.Show(ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRemover_Click(object? sender, EventArgs e)
    {
        if (IdSelecionado() is not int id) return;
        string nome = dgvAlunos.CurrentRow?.Cells["Nome"].Value?.ToString() ?? "";

        var resposta = MessageBox.Show($"Remover '{nome}' e todo o seu histórico de pontuações?", "ESA",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (resposta != DialogResult.Yes) return;

        try
        {
            _repo.Remover(id);
            txtNome.Clear();
            Recarregar();
        }
        catch (RegraNegocioException ex)
        {
            MessageBox.Show(ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
