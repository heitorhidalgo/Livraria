using Livraria.Models;

namespace Livraria.Interfaces
{
    public interface IAutorDAO
    {
        public void Incluir(string pNome, string pNacionalidade);
        public List<Autor> ListarTodos();
        public Autor BuscarPorId(int pId);
        public void Atualizar(Autor pAutor);
        public void Deletar(int pId);
    }
}
