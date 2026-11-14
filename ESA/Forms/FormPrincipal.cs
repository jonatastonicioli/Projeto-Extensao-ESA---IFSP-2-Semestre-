namespace ESA.Forms;

/// <summary>Janela principal: menu de navegação. Recebe o objeto Cadastro por referência.</summary>
public partial class FormPrincipal : Form
{
    private Cadastro cadastro;

    public FormPrincipal(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void abrir(Form janela)
    {
        using (janela)
        {
            janela.ShowDialog(this);
        }
    }

    private void btnCompetidores_Click(object? sender, EventArgs e) { abrir(new FormCompetidores(cadastro)); }
    private void btnInscricoes_Click(object? sender, EventArgs e) { abrir(new FormInscricoes(cadastro)); }
    private void btnNotas_Click(object? sender, EventArgs e) { abrir(new FormNotas(cadastro)); }
    private void btnRanking_Click(object? sender, EventArgs e) { abrir(new FormRanking(cadastro)); }
    private void btnSair_Click(object? sender, EventArgs e) { Close(); }
}
