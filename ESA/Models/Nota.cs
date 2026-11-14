namespace ESA.Models
{
    /// <summary>Nota dada por um avaliador a uma inscrição.</summary>
    public class Nota
    {
        private int id;
        private int inscricaoId;
        private int avaliadorId;
        private double valor;

        public Nota(int inscricaoId, int avaliadorId, double valor)
        {
            setInscricaoId(inscricaoId);
            setAvaliadorId(avaliadorId);
            setValor(valor);
        }

        public int getId() { return id; }
        public int getInscricaoId() { return inscricaoId; }
        public int getAvaliadorId() { return avaliadorId; }
        public double getValor() { return valor; }

        public void setId(int id) { this.id = id; }

        public void setInscricaoId(int inscricaoId)
        {
            if (inscricaoId <= 0) throw new RegraNegocioException("Selecione a inscrição.");
            this.inscricaoId = inscricaoId;
        }

        public void setAvaliadorId(int avaliadorId)
        {
            if (avaliadorId <= 0) throw new RegraNegocioException("Selecione o avaliador.");
            this.avaliadorId = avaliadorId;
        }

        // RF-05: a nota deve estar entre 0 e 100
        public void setValor(double valor)
        {
            if (valor < 0 || valor > 100)
                throw new RegraNegocioException("A nota deve estar entre 0 e 100.");
            this.valor = valor;
        }
    }
}
