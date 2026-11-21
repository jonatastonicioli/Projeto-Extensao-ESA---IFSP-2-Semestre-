namespace ESA.Models
{
    /// <summary>Inscrição de um competidor em uma modalidade de uma edição.</summary>
    ///  ///classe acessada quando o objeto Inscricao é criado no pelo button click no FormInscricao
    ///setter (validacoes) e getters (gravar no banco)
    public class Inscricao
    {
        private int id;
        private int competidorId;
        private int modalidadeId;
        private int edicaoId;
        private DateTime data;

        public Inscricao(int competidorId, int modalidadeId, int edicaoId)
        {
            setCompetidorId(competidorId);
            setModalidadeId(modalidadeId);
            setEdicaoId(edicaoId);
            data = DateTime.Today;
        }

        public int getId() { return id; }
        public int getCompetidorId() { return competidorId; }
        public int getModalidadeId() { return modalidadeId; }
        public int getEdicaoId() { return edicaoId; }
        public DateTime getData() { return data; }

        public void setId(int id) { this.id = id; }

        public void setCompetidorId(int competidorId)
        {
            if (competidorId <= 0) throw new RegraNegocioException("Selecione o competidor."); //Lança um erro com mensagem personalizada
            this.competidorId = competidorId;
        }

        public void setModalidadeId(int modalidadeId)
        {
            if (modalidadeId <= 0) throw new RegraNegocioException("Selecione a modalidade."); //Lança um erro com mensagem personalizada
            this.modalidadeId = modalidadeId;
        }

        public void setEdicaoId(int edicaoId)
        {
            if (edicaoId <= 0) throw new RegraNegocioException("Selecione a edição."); //Lança um erro com mensagem personalizada
            this.edicaoId = edicaoId;
        }
    }
}
