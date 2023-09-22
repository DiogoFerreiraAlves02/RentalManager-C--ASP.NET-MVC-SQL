using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models.Helpers {
    public class FuncionarioHelperCRUD {
        private string _conexaoBD;

        public FuncionarioHelperCRUD(string conexao) {
            _conexaoBD = conexao;
        }

        public List<Funcionario> list() {

            List<Funcionario> listaSaida = new List<Funcionario>();

            DataTable dtFuncionarios = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tFuncionario ORDER BY nome ASC";
            telefone.SelectCommand = comando;
            telefone.Fill(dtFuncionarios);
            conexao.Close();
            conexao.Dispose();
            //Transformar um conjunto de registos num conjunto de objetos
            foreach (DataRow linha in dtFuncionarios.Rows) {
                Funcionario funcionario = new Funcionario();
                funcionario.Id = Guid.Parse(linha["uid"].ToString());
                funcionario.Nome = linha["nome"].ToString();
                funcionario.Nif = linha["nif"].ToString();
                funcionario.Contacto = linha["contacto"].ToString();
                funcionario.NrFuncionario = linha["nrFuncionario"].ToString();
                listaSaida.Add(funcionario);
            }
            return listaSaida;
        }
        public Guid insert(Funcionario funcionario) {
            Guid idReturned = Guid.Empty;
            if (funcionario.Id == Guid.Empty) {
                funcionario.Id = Guid.NewGuid();
                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO tFuncionario (uid, nome, nif, contacto, nrFuncionario) " +
                                            " VALUES (@uid, @nome, @nif, @contacto, @nrFuncionario)";
                    comando.Parameters.AddWithValue("@uid", funcionario.Id);
                    comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                    comando.Parameters.AddWithValue("@nif", funcionario.Nif);
                    comando.Parameters.AddWithValue("@contacto", funcionario.Contacto);
                    comando.Parameters.AddWithValue("@nrFuncionario", funcionario.NrFuncionario);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = funcionario.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }
        public Funcionario read(string idAPesquisar) {

            Funcionario funcionarioSaida = new Funcionario();

            DataTable dtFuncionarios = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tFuncionario WHERE uid = @uid";
            comando.Parameters.AddWithValue("@uid", idAPesquisar);
            telefone.SelectCommand = comando;
            telefone.Fill(dtFuncionarios);
            conexao.Close();
            conexao.Dispose();
            if (dtFuncionarios.Rows.Count == 1) {
                DataRow linha = dtFuncionarios.Rows[0];     //e unica
                funcionarioSaida.Id = Guid.Parse(linha["uid"].ToString());
                funcionarioSaida.Nome = linha["nome"].ToString();
                funcionarioSaida.Nif = linha["nif"].ToString();
                funcionarioSaida.Contacto = linha["contacto"].ToString();
                funcionarioSaida.NrFuncionario = linha["nrFuncionario"].ToString();
            }
            return funcionarioSaida;        //ou vem da BD ou é um novo pq o id não existe
        }

        public Guid update(Funcionario funcionario) {
            Guid idReturned = Guid.Empty;
            if (funcionario.Id != Guid.Empty) {

                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE tFuncionario SET nome = @nome, nif = @nif, contacto = @contacto, " +
                        "nrFuncionario = @nrFuncionario WHERE uid = @uid";

                    comando.Parameters.AddWithValue("@uid", funcionario.Id);
                    comando.Parameters.AddWithValue("@nif", funcionario.Nif);
                    comando.Parameters.AddWithValue("@contacto", funcionario.Contacto);
                    comando.Parameters.AddWithValue("@nrFuncionario", funcionario.NrFuncionario);
                    comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = funcionario.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }

        public Funcionario eliminar(string idAEliminar) {

            Funcionario funcionarioEliminado = new Funcionario();

            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM tFuncionario WHERE uid = @uid; DELETE FROM tAluguer WHERE funcionario = @uid;";
            comando.Parameters.AddWithValue("@uid", idAEliminar);
            telefone.SelectCommand = comando;
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            conexao.Dispose();

            return funcionarioEliminado;        //ou vem da BD ou é um novo pq o id não existe
        }
    }
}
