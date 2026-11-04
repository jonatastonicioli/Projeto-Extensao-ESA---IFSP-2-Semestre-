using System.Globalization;
using ESA.Data;
using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Forms;

/// <summary>RF-04 (e RF-05): registrar, editar e remover pontuações de peças de um aluno.</summary>
public partial class FormPontuacao : Form
{
    private readonly AlunoRepository _alunos;
    private readonly PontuacaoRepository _pontuacoes;

    public FormPontuacao(AlunoRepository alunos, PontuacaoRepository pontuacoes)
    {
        InitializeComponent();
        _alunos = alunos;
        _pontuacoes = pontuacoes;
    }

    private void FormPontuacao_Load(object? sender, EventArgs e)
    {
        try
        {
            cmbAluno.DataSource = _alunos.Listar();   // usa Aluno.ToString()
            if (cmbAluno.Items.Count == 0)
                MessageBox.Show("Nenhum aluno cadastrado. Cadastre um aluno primeiro.", "ESA",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cmbAluno_SelectedIndexChanged(object? sender, EventArgs e) => CarregarHistorico();

    private void CarregarHistorico()
    {
        if (cmbAluno.SelectedItem is not Aluno aluno) return;
        try
        {
            var tabela = new System.Data.DataTable();
            tabela.Columns.Add("Cód.", typeof(int));
            tabela.Columns.Add("Peça", typeof(int));
            tabela.Columns.Add("Pontuação", typeof(string));
            tabela.Columns.Add("Registrada em", typeof(string));
            int n = 1;
            foreach (Pontuacao p in _pontuacoes.ListarPorAluno(aluno.Id))
                tabela.Rows.Add(p.Id, n++, p.Valor.ToString("0.00"), p.DataRegistro.ToString("dd/MM/yyyy HH:mm"));
            dgvHistorico.DataSource = tabela;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>Lê o campo de nota com Parse (pode lançar FormatException).</summary>
    private double LerNota()
    {
        return double.Parse(txtNota.Text.Trim(), CultureInfo.GetCultureInfo("pt-BR"));
    }

    private void btnRegistrar_Click(object? sender, EventArgs e)
    {
        if (cmbAluno.SelectedItem is not Aluno aluno)
        {
            MessageBox.Show("Selecione um aluno.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            var p = new Pontuacao(aluno.Id, LerNota());   // valida 0..100 (throw)
            _pontuacoes.Inserir(p);
            txtNota.Clear();
            CarregarHistorico();
        }
        catch (FormatException)
        {
            MessageBox.Show("Valor inválido. Digite um número (ex.: 85,5).", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void btnAlterar_Click(object? sender, EventArgs e)
    {
        if (dgvHistorico.CurrentRow?.Cells["Cód."].Value is not int id || cmbAluno.SelectedItem is not Aluno aluno)
        {
            MessageBox.Show("Selecione uma pontuação no histórico.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            var p = new Pontuacao(id, aluno.Id, LerNota(), DateTime.Now);
            _pontuacoes.Atualizar(p);
            txtNota.Clear();
            CarregarHistorico();
        }
        catch (FormatException)
        {
            MessageBox.Show("Valor inválido. Digite um número (ex.: 85,5).", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void btnExcluir_Click(object? sender, EventArgs e)
    {
        if (dgvHistorico.CurrentRow?.Cells["Cód."].Value is not int id)
        {
            MessageBox.Show("Selecione uma pontuação no histórico.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var resposta = MessageBox.Show("Excluir a pontuação selecionada?", "ESA",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (resposta != DialogResult.Yes) return;

        try
        {
            _pontuacoes.Remover(id);
            CarregarHistorico();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
