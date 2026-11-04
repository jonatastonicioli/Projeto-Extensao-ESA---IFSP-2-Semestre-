namespace ESA.Models;

/// <summary>Competidor / estudante da modalidade de Usinagem CNC.</summary>
public class Aluno
{
    // Campos privados
    private int _id;
    private string _nome = "";
    private int _qtdPecas;

    public const int MaxAlunos = 50;

    // Construtores
    public Aluno(string nome)
    {
        Nome = nome;
    }

    public Aluno(int id, string nome, int qtdPecas) : this(nome)
    {
        _id = id;
        _qtdPecas = qtdPecas;
    }

    // Getters e Setters
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Nome
    {
        get { return _nome; }
        set
        {
            ValidarNome(value);          // lança RegraNegocioException se inválido
            _nome = value.Trim();
        }
    }

    public int QtdPecas
    {
        get { return _qtdPecas; }
        set { _qtdPecas = value; }
    }

    /// <summary>
    /// Método geral com passagem de valor (nome) e lançamento de exceção de regra de negócio.
    /// RF-01: mínimo 2 caracteres, somente letras e espaços.
    /// </summary>
    public static void ValidarNome(string? nome)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 2)
            throw new RegraNegocioException("Nome inválido: informe ao menos 2 caracteres.");

        foreach (char c in nome)
        {
            if (!char.IsLetter(c) && c != ' ')
                throw new RegraNegocioException("Nome inválido: use apenas letras e espaços.");
        }
    }

    public override string ToString() => $"{Id} - {Nome}";
}
