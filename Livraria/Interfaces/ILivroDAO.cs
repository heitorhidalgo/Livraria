using Livraria.Models;

namespace Livraria.Interfaces
{
    public interface ILivroDAO
    {
        public void Incluir(string pTitulo, string pGenero, int pAnoPublicacao, int pAutorId);
        public List<Livro> ListarTodos();
        public Livro BuscarPorId(int pId);
        public void Atualizar(Livro pTitulo);
        public void Deletar(int pId);
    }
}

