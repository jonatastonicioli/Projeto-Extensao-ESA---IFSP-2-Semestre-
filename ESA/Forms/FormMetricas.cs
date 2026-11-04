using ESA.Data;
using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Forms;

/// <summary>RF-05, RF-06, RF-07: histórico e métricas de um competidor.</summary>
public partial class FormMetricas : Form
{
    private readonly AlunoRepository _alunos;
    private readonly PontuacaoRepository _pontuacoes;
    private List<Pontuacao> _atuais = new();

    public FormMetricas(AlunoRepository alunos, PontuacaoRepository pontuacoes)
    {
        InitializeComponent();
        _alunos = alunos;
        _pontuacoes = pontuacoes;
    }

    private void FormMetricas_Load(object? sender, EventArgs e)
    {
        try
        {
            cmbAluno.DataSource = _alunos.Listar();
            if (cmbAluno.Items.Count == 0)
                MessageBox.Show("Nenhum aluno cadastrado.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cmbAluno_SelectedIndexChanged(object? sender, EventArgs e) => Atualizar();

    private void Atualizar()
    {
        if (cmbAluno.SelectedItem is not Aluno aluno) return;
        try
        {
            _atuais = _pontuacoes.ListarPorAluno(aluno.Id);

            var tabela = new System.Data.DataTable();
            tabela.Columns.Add("Peça", typeof(int));
            tabela.Columns.Add("Pontuação", typeof(string));
            for (int i = 0; i < _atuais.Count; i++)
                tabela.Rows.Add(i + 1, _atuais[i].Valor.ToString("0.00"));
            dgvPontuacoes.DataSource = tabela;

            Metricas m = Metricas.Calcular(_atuais);
            if (m.Quantidade == 0)
            {
                lblMedia.Text = "Nenhuma pontuação registrada";
                lblMaior.Text = lblMenor.Text = lblQtd.Text = "";
                return;
            }
            lblMedia.Text = $"Média: {m.Media:0.00}";
            lblMaior.Text = $"Maior nota: {m.Maior:0.00}";
            lblMenor.Text = $"Menor nota: {m.Menor:0.00}";
            lblQtd.Text = $"Peças avaliadas: {m.Quantidade}";
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnGrafico_Click(object? sender, EventArgs e)
    {
        if (cmbAluno.SelectedItem is not Aluno aluno) return;
        try
        {
            if (_atuais.Count < 2)
                throw new RegraNegocioException("Não há dados suficientes para gerar o gráfico (mínimo de 2 pontuações).");
            using var f = new FormGrafico(aluno, _atuais);
            f.ShowDialog(this);
        }
        catch (RegraNegocioException ex)
        {
            MessageBox.Show(ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
