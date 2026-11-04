using ESA.Data;
using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Forms;

/// <summary>RF-08: ranking geral ordenado pela média.</summary>
public partial class FormRanking : Form
{
    private readonly AlunoRepository _alunos;
    private readonly PontuacaoRepository _pontuacoes;

    public FormRanking(AlunoRepository alunos, PontuacaoRepository pontuacoes)
    {
        InitializeComponent();
        _alunos = alunos;
        _pontuacoes = pontuacoes;
    }

    private void FormRanking_Load(object? sender, EventArgs e) => Carregar();

    private void Carregar()
    {
        try
        {
            List<Aluno> alunos = _alunos.Listar();
            if (alunos.Count == 0)
            {
                MessageBox.Show("Nenhum competidor cadastrado.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Calcula as métricas de cada aluno
            var linhas = new List<(Aluno Aluno, Metricas Metricas)>();
            foreach (Aluno a in alunos)
                linhas.Add((a, Metricas.Calcular(_pontuacoes.ListarPorAluno(a.Id))));

            // Maior média primeiro; quem não tem notas ("N/A") vai para o final
            var ordenado = linhas
                .OrderByDescending(l => l.Metricas.Quantidade > 0)
                .ThenByDescending(l => l.Metricas.Media)
                .ThenBy(l => l.Aluno.Nome)
                .ToList();

            var tabela = new System.Data.DataTable();
            foreach (string c in new[] { "Pos", "Nome", "Média", "Maior", "Menor", "Peças" })
                tabela.Columns.Add(c, typeof(string));

            int pos = 1;
            foreach (var l in ordenado)
            {
                if (l.Metricas.Quantidade > 0)
                    tabela.Rows.Add(pos++.ToString(), l.Aluno.Nome, l.Metricas.Media.ToString("0.00"),
                                    l.Metricas.Maior.ToString("0.00"), l.Metricas.Menor.ToString("0.00"),
                                    l.Metricas.Quantidade.ToString());
                else
                    tabela.Rows.Add(pos++.ToString(), l.Aluno.Nome, "N/A", "N/A", "N/A", "0");
            }
            dgvRanking.DataSource = tabela;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Erro de banco de dados: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
