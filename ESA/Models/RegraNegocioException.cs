namespace ESA.Models;

/// <summary>
/// Exceção disparada pela aplicação (via throw) quando uma regra de negócio não é satisfeita.
/// </summary>
public class RegraNegocioException : Exception
{
    public RegraNegocioException(string mensagem) : base(mensagem) { }
}
