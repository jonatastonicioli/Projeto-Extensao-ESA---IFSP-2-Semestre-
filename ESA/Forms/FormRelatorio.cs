using System.Text;
using ESA.Data;
using ESA.Models;
using MySql.Data.MySqlClient;

namespace ESA.Forms;

/// <summary>RF-09: relatório consolidado exibido em tela e exportável para .txt.</summary>
public partial class FormRelatorio : Form
{
    private readonly AlunoRepository _alunos;
    private readonly PontuacaoRepository _pontuacoes;

    public FormRelatorio(AlunoRepository alunos, PontuacaoRepository pontuacoes)
    {
        InitializeComponent();
        _alunos = alunos;
        _pontuacoes = pontuacoes;
    }

    private void FormRelatorio_Load(object? sender, EventArgs e)
    {
        try
        {
            txtRelatorio.Text = GerarRelatorio();
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

    private string GerarRelatorio()
    {
        List<Aluno> alunos = _alunos.Listar();
        if (alunos.Count == 0)
            throw new RegraNegocioException("Não há dados para compor o relatório (nenhum competidor cadastrado).");

        var sb = new StringBuilder();
        sb.AppendLine("============================================================");
        sb.AppendLine("  ESA - Evaluation System Analyzer");
        sb.AppendLine("  SENAI Roberto Mange - Usinagem CNC");
        sb.AppendLine($"  Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}");
        sb.AppendLine("============================================================");
        sb.AppendLine();
        sb.AppendLine($"  Total de competidores: {alunos.Count}");
        sb.AppendLine();

        foreach (Aluno a in alunos)
        {
            List<Pontuacao> notas = _pontuacoes.ListarPorAluno(a.Id);
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine($"  Aluno : {a.Nome}  (ID: {a.Id})");
            sb.AppendLine($"  Peças avaliadas: {notas.Count}");

            if (notas.Count == 0)
            {
                sb.AppendLine("  Sem pontuações registradas.");
            }
            else
            {
                for (int i = 0; i < notas.Count; i++)
                    sb.AppendLine($"    Peça {i + 1,2}: {notas[i].Valor,6:0.00}   ({notas[i].DataRegistro:dd/MM/yyyy HH:mm})");

                Metricas m = Metricas.Calcular(notas);
                sb.AppendLine($"  Média      : {m.Media:0.00}");
                sb.AppendLine($"  Maior nota : {m.Maior:0.00}");
                sb.AppendLine($"  Menor nota : {m.Menor:0.00}");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private void btnExportar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtRelatorio.Text)) return;
        using var dlg = new SaveFileDialog { Filter = "Texto (*.txt)|*.txt", FileName = "esa_relatorio.txt" };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            File.WriteAllText(dlg.FileName, txtRelatorio.Text, Encoding.UTF8);
            MessageBox.Show("Relatório exportado com sucesso.", "ESA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (IOException ex)
        {
            MessageBox.Show("Não foi possível gravar o arquivo: " + ex.Message, "ESA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
