using Livraria.Interfaces;
using Livraria.DAO;
using Livraria.Models;
using System.Reflection.PortableExecutable;
using Microsoft.Data.SqlClient;

namespace Livraria.Services
{
    public class AutorService : IAutorService
    {
        private AutorDAO _autorDAO;

        public AutorService(string connectionString)
        {
            _autorDAO = new AutorDAO(connectionString);
        }

        public void AdicionarAutor(string pNome, string pNacionalidade)
        {
            if (string.IsNullOrWhiteSpace(pNome) || string.IsNullOrWhiteSpace(pNacionalidade))
                throw new Exception("Nome e o Nacionalidade são obrigatórios.");

            _autorDAO.Incluir(pNome, pNacionalidade);
        }

        public void AtualizarAutor(Autor pAutor)
        {
            if (pAutor == null)
                throw new Exception("Autor Inválido");

            if (string.IsNullOrWhiteSpace(pAutor.Nome) || string.IsNullOrWhiteSpace(pAutor.Nacionalidade))
                throw new Exception("Nome e o Nacionalidade são obrigatórios.");

            _autorDAO.Atualizar(pAutor);
        }

        public Autor BuscarAutor(int pId)
        {
            return _autorDAO.BuscarPorId(pId);
        }

        public List<Autor> ListarAutores()
        {
            return _autorDAO.ListarTodos();
        }

        public void RemoverAutor(int pId)
        {
            Autor autor = _autorDAO.BuscarPorId(pId);

            if (autor == null)
                throw new Exception("O Autor não foi encontrado");

            _autorDAO.Deletar(pId);
        }

        public List<Autor> PesquisarAutorPorNome(string nome)
        {
            return _autorDAO.BuscarPorNome(nome);
        }

    }
}
