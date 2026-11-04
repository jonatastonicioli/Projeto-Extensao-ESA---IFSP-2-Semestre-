using ESA.Data;

namespace ESA.Forms;

/// <summary>Janela principal: menu de navegação. Recebe os repositórios por referência.</summary>
public partial class FormPrincipal : Form
{
    private readonly AlunoRepository _alunos;
    private readonly PontuacaoRepository _pontuacoes;

    public FormPrincipal(AlunoRepository alunos, PontuacaoRepository pontuacoes)
    {
        InitializeComponent();
        _alunos = alunos;
        _pontuacoes = pontuacoes;
    }

    private void btnAlunos_Click(object? sender, EventArgs e)
    {
        using var f = new FormAlunos(_alunos);
        f.ShowDialog(this);
    }

    private void btnPontuacao_Click(object? sender, EventArgs e)
    {
        using var f = new FormPontuacao(_alunos, _pontuacoes);
        f.ShowDialog(this);
    }

    private void btnMetricas_Click(object? sender, EventArgs e)
    {
        using var f = new FormMetricas(_alunos, _pontuacoes);
        f.ShowDialog(this);
    }

    private void btnRanking_Click(object? sender, EventArgs e)
    {
        using var f = new FormRanking(_alunos, _pontuacoes);
        f.ShowDialog(this);
    }

    private void btnRelatorio_Click(object? sender, EventArgs e)
    {
        using var f = new FormRelatorio(_alunos, _pontuacoes);
        f.ShowDialog(this);
    }

    private void btnSair_Click(object? sender, EventArgs e) => Close();
}
