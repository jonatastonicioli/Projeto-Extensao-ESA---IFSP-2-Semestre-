using ESA.Models;

namespace ESA.Forms;

/// <summary>RF-10: gráfico de Notas x Tempo desenhado com GDI+.</summary>
public partial class FormGrafico : Form
{
    private readonly Aluno _aluno;
    private readonly List<Pontuacao> _pontos;

    public FormGrafico(Aluno aluno, List<Pontuacao> pontos)
    {
        InitializeComponent();
        _aluno = aluno;
        _pontos = pontos;
        Text = $"Evolução - {aluno.Nome}";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        var area = new Rectangle(60, 50, ClientSize.Width - 100, ClientSize.Height - 120);
        using var fonte = new Font("Segoe UI", 9f);
        using var fonteTitulo = new Font("Segoe UI", 12f, FontStyle.Bold);
        g.DrawString($"Notas x Tempo - {_aluno.Nome}", fonteTitulo, Brushes.Black, 20, 10);

        // Grade e eixo Y (0 a 100)
        using var penGrade = new Pen(Color.LightGray);
        for (int v = 0; v <= 100; v += 20)
        {
            float y = area.Bottom - (float)(v / 100.0) * area.Height;
            g.DrawLine(penGrade, area.Left, y, area.Right, y);
            g.DrawString(v.ToString(), fonte, Brushes.Black, area.Left - 35, y - 8);
        }
        g.DrawRectangle(Pens.Black, area);

        if (_pontos.Count < 2) return;

        var pts = new PointF[_pontos.Count];
        for (int i = 0; i < _pontos.Count; i++)
        {
            float x = area.Left + (float)i / (_pontos.Count - 1) * area.Width;
            float y = area.Bottom - (float)(_pontos[i].Valor / 100.0) * area.Height;
            pts[i] = new PointF(x, y);
        }

        using var penLinha = new Pen(Color.SteelBlue, 2.5f);
        g.DrawLines(penLinha, pts);

        for (int i = 0; i < pts.Length; i++)
        {
            g.FillEllipse(Brushes.SteelBlue, pts[i].X - 4, pts[i].Y - 4, 8, 8);
            g.DrawString(_pontos[i].Valor.ToString("0.0"), fonte, Brushes.Black, pts[i].X - 12, pts[i].Y - 22);
            g.DrawString(_pontos[i].DataRegistro.ToString("dd/MM\nHH:mm"), fonte, Brushes.DimGray,
                         pts[i].X - 18, area.Bottom + 6);
        }
    }
}
