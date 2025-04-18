using Livraria.Interfaces;
using Livraria.Models;

namespace Livraria.DAO
{
    public class AutorDAO : IAutorDAO
    {
        private string _connectionString;

        public AutorDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Atualizar(Autor pAutor)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Autor SET Nome = @Nome, Nacionalidade = @Nacionalidade WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", pAutor.Nome);
                cmd.Parameters.AddWithValue("@Nacionalidade", pAutor.Nacionalidade);
                cmd.Parameters.AddWithValue("@Id", pAutor.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Autor BuscarPorId(int pId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", pId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Autor()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Nacionalidade = reader.GetString(2),
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
                string query = "DELETE FROM Autor WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Id", pId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Incluir(string pNome, string pNacionalidade)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Autor (Nome, Nacionalidade) VALUES (@Nome, @Nacionalidade)";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Nome", pNome);
                command.Parameters.AddWithValue("@Nacionalidade", pNacionalidade);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Autor> ListarTodos()
        {
            List<Autor> retorno = new List<Autor>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Autor";

                SqlCommand command = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Autor autor = new Autor()
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Nacionalidade = reader["Nacionalidade"].ToString()
                    };

                    retorno.Add(autor);
                }
            }

            return retorno;
        }
    }
}
