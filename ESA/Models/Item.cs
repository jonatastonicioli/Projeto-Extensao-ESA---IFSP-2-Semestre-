namespace ESA.Models
{
    /// <summary>Par (id, texto) usado para preencher ComboBox com dados do banco.</summary>
    public class Item
    {
        private int id;
        private string texto = "";

        public Item(int id, string texto)
        {
            this.id = id;
            this.texto = texto;
        }

        public int getId() { return id; }
        public string getTexto() { return texto; }

        // o ComboBox mostra o resultado deste método
        public override string ToString()
        {
            return texto;
        }
    }
}
