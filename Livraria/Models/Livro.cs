namespace Livraria.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Título { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }
    }
}
