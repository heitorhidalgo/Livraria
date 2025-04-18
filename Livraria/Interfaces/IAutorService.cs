using Livraria.Models;

namespace Livraria.Interfaces
{
    public interface IAutorService
    {
        public void AdicionarAutor(string pNome, string pNacionalidade);
        List<Autor> ListarAutores();
        Autor BuscarAutor(int pId);
        void AtualizarAutor(Autor pAutor);
        void RemoverAutor(int pId);
    }
}
