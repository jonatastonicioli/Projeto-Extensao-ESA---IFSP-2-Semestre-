namespace ESA.Models
{
    /// <summary>Inscrição de um competidor em uma modalidade de uma edição.</summary>
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
            if (competidorId <= 0) throw new RegraNegocioException("Selecione o competidor.");
            this.competidorId = competidorId;
        }

        public void setModalidadeId(int modalidadeId)
        {
            if (modalidadeId <= 0) throw new RegraNegocioException("Selecione a modalidade.");
            this.modalidadeId = modalidadeId;
        }

        public void setEdicaoId(int edicaoId)
        {
            if (edicaoId <= 0) throw new RegraNegocioException("Selecione a edição.");
            this.edicaoId = edicaoId;
        }
    }
}
