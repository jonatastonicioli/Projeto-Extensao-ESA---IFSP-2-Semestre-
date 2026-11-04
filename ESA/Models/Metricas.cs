namespace ESA.Models;

/// <summary>Métricas de desempenho de um competidor (RF-06).</summary>
public class Metricas
{
    private double _media;
    private double _maior;
    private double _menor;
    private int _quantidade;

    public Metricas(double media, double maior, double menor, int quantidade)
    {
        _media = media;
        _maior = maior;
        _menor = menor;
        _quantidade = quantidade;
    }

    public double Media { get { return _media; } }
    public double Maior { get { return _maior; } }
    public double Menor { get { return _menor; } }
    public int Quantidade { get { return _quantidade; } }

    /// <summary>
    /// Calcula média, maior e menor pontuação. Sem pontuações, retorna métricas zeradas.
    /// Método geral com passagem (lista) e retorno de valor (Metricas).
    /// </summary>
    public static Metricas Calcular(IList<Pontuacao> pontuacoes)
    {
        if (pontuacoes.Count == 0)
            return new Metricas(0, 0, 0, 0);

        double soma = 0;
        double maior = pontuacoes[0].Valor;
        double menor = pontuacoes[0].Valor;

        foreach (Pontuacao p in pontuacoes)
        {
            soma += p.Valor;
            if (p.Valor > maior) maior = p.Valor;
            if (p.Valor < menor) menor = p.Valor;
        }

        return new Metricas(soma / pontuacoes.Count, maior, menor, pontuacoes.Count);
    }
}
