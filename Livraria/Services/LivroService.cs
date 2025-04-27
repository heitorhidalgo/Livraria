using Livraria.Interfaces;
using Livraria.DAO;
using Livraria.Models;
using System.Reflection.PortableExecutable;
using Microsoft.Data.SqlClient;

namespace Livraria.Services
{
    public class LivroService : ILivroService
    {
        private LivroDAO _livroDAO;

        public LivroService(string connectionString)
        {
            _livroDAO = new LivroDAO(connectionString);
        }

        public void AdicionarLivro(string pTitulo, string pGenero, int pAnoPublicacao, int pAutorId)
        {
            if (string.IsNullOrWhiteSpace(pTitulo) || string.IsNullOrWhiteSpace(pGenero) || int.IsNegative(pAnoPublicacao) || int.IsNegative(pAutorId))
                throw new Exception("Titulo, Genero, Ano de publicação e AutorId são obrigatórios.");

            _livroDAO.Incluir(pTitulo, pGenero, pAnoPublicacao, pAutorId);
        }

        public void AtualizarLivro(Livro pLivro)
        {
            if (pLivro == null)
                throw new Exception("Livro Inválido");

            if (string.IsNullOrWhiteSpace(pLivro.Título) || string.IsNullOrWhiteSpace(pLivro.Genero) || int.IsNegative(pLivro.AnoPublicacao) || int.IsNegative(pLivro.AutorId))
                throw new Exception("Titulo, Genero, Ano de publicação e AutorId são obrigatórios.");

            _livroDAO.Atualizar(pLivro);
        }

        public Livro BuscarLivro(int pId)
        {
            return _livroDAO.BuscarPorId(pId);
        }

        public List<Livro> ListarLivros()
        {
            return _livroDAO.ListarTodos();
        }

        public void RemoverLivro(int pId)
        {
            Livro livro = _livroDAO.BuscarPorId(pId);

            if (livro == null)
                throw new Exception("O Livro não foi encontrado");

            _livroDAO.Deletar(pId);
        }

        public List<Livro> PesquisarLivroPorNome(string nome)
        {
            return _livroDAO.BuscarPorNome(nome);
        }

    }
}
