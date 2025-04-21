using Livraria.Models;

namespace Livraria.Interfaces
{
    public interface ILivroService
    {
        public void AdicionarLivro(string pTitulo, string pGenero, int pAnoPublicacao, int pAutorId);
        List<Livro> ListarLivros();
        Livro BuscarLivro(int pId);
        void AtualizarLivro(Livro pTitulo);
        void RemoverLivro(int pId);
    }
}

