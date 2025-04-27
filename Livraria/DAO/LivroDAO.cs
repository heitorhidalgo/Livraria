using Livraria.Interfaces;
using Livraria.Models;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Livraria.DAO
{
    public class LivroDAO : ILivroDAO
    {
        private string _connectionString;

        public LivroDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Atualizar(Livro pLivro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Livro SET Título = @Título, Genero = @Genero, AnoPublicacao = @AnoPublicacao, AutorId = @AutorId WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Título", pLivro.Título);
                cmd.Parameters.AddWithValue("@Genero", pLivro.Genero);
                cmd.Parameters.AddWithValue("@AnoPublicacao", pLivro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@AutorId", pLivro.AutorId);
                cmd.Parameters.AddWithValue("@Id", pLivro.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Livro BuscarPorId(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Livro()
                    {
                        Id = reader.GetInt32(0),
                        Título = reader.GetString(1),
                        Genero = reader.GetString(2),
                        AnoPublicacao = reader.GetInt32(3),
                        AutorId = reader.GetInt32(4) 
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public void Deletar(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Livro WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", pId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Incluir(string pTítulo, string pGenero, int pAnoPublicacao, int pAutorId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Livro (Título, Genero, AnoPublicacao, AutorId) VALUES (@Título, @Genero, @AnoPublicacao, @AutorId)";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Título", pTítulo);
                command.Parameters.AddWithValue("@Genero", pGenero);
                command.Parameters.AddWithValue("@AnoPublicacao", pAnoPublicacao);
                command.Parameters.AddWithValue("@AutorId", pAutorId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Livro> ListarTodos()
        {
            List<Livro> retorno = new List<Livro>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro";

                SqlCommand command = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livro livro = new Livro()
                    {
                        Id = (int)reader["Id"],
                        Título = reader["Título"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        AnoPublicacao = (int)reader["AnoPublicacao"],
                        AutorId = (int)reader["AutorId"]
                    };

                    retorno.Add(livro);
                }
            }

            return retorno;
        }

        public List<Livro> BuscarPorNome(string nome)
        {
            List<Livro> retorno = new List<Livro>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Livro WHERE Título = @Nome";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Nome", nome);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Livro livro = new Livro()
                    {
                        Id = (int)reader["Id"],
                        Título = reader["Título"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        AnoPublicacao = (int)reader["AnoPublicacao"],
                        AutorId = (int)reader["AutorId"]
                    };

                    retorno.Add(livro);
                }
            }

            return retorno;
        }

    }
}
