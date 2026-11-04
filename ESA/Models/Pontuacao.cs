namespace ESA.Models;

/// <summary>Pontuação obtida por um aluno em uma peça produzida.</summary>
public class Pontuacao
{
    private int _id;
    private int _alunoId;
    private double _valor;
    private DateTime _dataRegistro;

    public const double NotaMin = 0.0;
    public const double NotaMax = 100.0;
    public const int MaxPecasPorAluno = 20;

    public Pontuacao(int alunoId, double valor)
    {
        AlunoId = alunoId;
        Valor = valor;
        _dataRegistro = DateTime.Now;
    }

    public Pontuacao(int id, int alunoId, double valor, DateTime dataRegistro) : this(alunoId, valor)
    {
        _id = id;
        _dataRegistro = dataRegistro;
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public int AlunoId
    {
        get { return _alunoId; }
        set { _alunoId = value; }
    }

    public double Valor
    {
        get { return _valor; }
        set
        {
            if (!NotaValida(value))
                throw new RegraNegocioException(
                    $"Pontuação inválida: informe um valor entre {NotaMin:0.0} e {NotaMax:0.0}.");
            _valor = value;
        }
    }

    public DateTime DataRegistro
    {
        get { return _dataRegistro; }
        set { _dataRegistro = value; }
    }

    public static bool NotaValida(double nota)
    {
        return nota >= NotaMin && nota <= NotaMax;
    }
}
