namespace ESA.Models
{
    /// <summary>Nota dada por um avaliador a uma inscrição.</summary>
    ///classe acessada quando o objeto Nota é criado no pelo button click no FormNotas
    ///setter (validacoes) e getters (gravar no banco)
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

        public int getId() { return id; } // usado pelo Cadastro para gravar no banco
        public int getInscricaoId() { return inscricaoId; } // usado pelo Cadastro para gravar no banco
        public int getAvaliadorId() { return avaliadorId; } // usado pelo Cadastro para gravar no banco
        public double getValor() { return valor; } // usado pelo Cadastro para gravar no banco

        public void setId(int id) { this.id = id; } //Sets validam as informações entrado pelo usuario

        public void setInscricaoId(int inscricaoId)
        {
            if (inscricaoId <= 0) throw new RegraNegocioException("Selecione a inscrição."); //Lança um erro com mensagem personalizada
            this.inscricaoId = inscricaoId;
        }

        public void setAvaliadorId(int avaliadorId)
        {
            if (avaliadorId <= 0) throw new RegraNegocioException("Selecione o avaliador."); //Lança um erro com mensagem personalizada
            this.avaliadorId = avaliadorId;
        }

        // RF-05: a nota deve estar entre 0 e 100
        public void setValor(double valor)
        {
            if (valor < 0 || valor > 100)
                throw new RegraNegocioException("A nota deve estar entre 0 e 100."); //Lança um erro com mensagem personalizada
            this.valor = valor;
        }
    }
}
