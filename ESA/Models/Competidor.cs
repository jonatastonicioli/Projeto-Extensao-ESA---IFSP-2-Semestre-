namespace ESA.Models
{
    /// <summary>Competidor (tabelas usuario + competidor).</summary>
    public class Competidor
    {
        public const int MaxCompetidores = 50;

        private int id;
        private string nome = "";
        private string email = "";
        private int instituicaoId;
        private string telefone = "";

        public Competidor(string nome, string email, int instituicaoId, string telefone)
        {
            setNome(nome);
            setEmail(email);
            setInstituicaoId(instituicaoId);
            setTelefone(telefone);
        }

        // ---------- getters ----------
        public int getId() { return id; }
        public string getNome() { return nome; }
        public string getEmail() { return email; }
        public int getInstituicaoId() { return instituicaoId; }
        public string getTelefone() { return telefone; }

        // ---------- setters (com validação) ----------
        public void setId(int id) { this.id = id; }

        // RF-01: mínimo 2 caracteres, somente letras e espaços
        public void setNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 2)
                throw new RegraNegocioException("Nome inválido: informe ao menos 2 caracteres.");

            foreach (char c in nome)
            {
                if (!char.IsLetter(c) && c != ' ')
                    throw new RegraNegocioException("Nome inválido: use apenas letras e espaços.");
            }
            this.nome = nome.Trim();
        }

        public void setEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
                throw new RegraNegocioException("E-mail inválido.");
            this.email = email.Trim();
        }

        public void setInstituicaoId(int instituicaoId)
        {
            if (instituicaoId <= 0)
                throw new RegraNegocioException("Selecione a instituição.");
            this.instituicaoId = instituicaoId;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone == null ? "" : telefone.Trim();
        }
    }
}
