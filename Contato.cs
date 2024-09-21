namespace GerenciadorContatosApp
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Contato(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, Telefone: {Telefone}";
        }

        public string ToCSV()
        {
            return $"{Nome},{Email},{Telefone}";
        }

        public static Contato FromCSV(string csvLine)
        {
            var values = csvLine.Split(',');
            return new Contato(values[0], values[1], values[2]);
        }
    }
}
