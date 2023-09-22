using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models.Helpers {
    public class ClienteHelperCRUD {
        private string _conexaoBD;

        public ClienteHelperCRUD(string conexao) {
            _conexaoBD = conexao;
        }

        public List<Cliente> list() {

            List<Cliente> listaSaida = new List<Cliente>();

            DataTable dtClientes = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tCliente ORDER BY nome ASC";
            telefone.SelectCommand = comando;
            telefone.Fill(dtClientes);
            conexao.Close();
            conexao.Dispose();
            //Transformar um conjunto de registos num conjunto de objetos
            foreach (DataRow linha in dtClientes.Rows) {
                Cliente cliente = new Cliente();
                cliente.Id = Guid.Parse(linha["uid"].ToString());
                cliente.Nome = linha["nome"].ToString();
                cliente.Nif = linha["nif"].ToString();
                cliente.Contacto = linha["contacto"].ToString();
                cliente.Morada = linha["morada"].ToString();
                listaSaida.Add(cliente);
            }
            return listaSaida;
        }

        public Guid insert(Cliente cliente) {
            Guid idReturned = Guid.Empty;
            if (cliente.Id == Guid.Empty) {
                cliente.Id = Guid.NewGuid();
                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO tCliente (uid, nome, nif, contacto, morada) " +
                                            " VALUES (@uid, @nome, @nif, @contacto, @morada)";
                    comando.Parameters.AddWithValue("@uid", cliente.Id);
                    comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    comando.Parameters.AddWithValue("@nif", cliente.Nif);
                    comando.Parameters.AddWithValue("@contacto", cliente.Contacto);
                    comando.Parameters.AddWithValue("@morada", cliente.Morada);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = cliente.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }
        public Cliente read(string idAPesquisar) {

            Cliente clienteSaida = new Cliente();

            DataTable dtClientes = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tCliente WHERE uid = @uid";
            comando.Parameters.AddWithValue("@uid", idAPesquisar);
            telefone.SelectCommand = comando;
            telefone.Fill(dtClientes);
            conexao.Close();
            conexao.Dispose();
            if (dtClientes.Rows.Count == 1) {
                DataRow linha = dtClientes.Rows[0];     //e unica
                clienteSaida.Id = Guid.Parse(linha["uid"].ToString());
                clienteSaida.Nome = linha["nome"].ToString();
                clienteSaida.Nif = linha["nif"].ToString();
                clienteSaida.Contacto = linha["contacto"].ToString();
                clienteSaida.Morada = linha["morada"].ToString();
            }
            return clienteSaida;        //ou vem da BD ou é um novo pq o id não existe
        }

        public Guid update(Cliente cliente) {
            Guid idReturned = Guid.Empty;
            if (cliente.Id != Guid.Empty) {

                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE tCliente SET nome = @nome, nif = @nif, contacto = @contacto, " +
                        "morada = @morada WHERE uid = @uid";

                    comando.Parameters.AddWithValue("@uid", cliente.Id);
                    comando.Parameters.AddWithValue("@nif", cliente.Nif);
                    comando.Parameters.AddWithValue("@contacto", cliente.Contacto);
                    comando.Parameters.AddWithValue("@morada", cliente.Morada);
                    comando.Parameters.AddWithValue("@nome", cliente.Nome);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = cliente.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }

        public Cliente eliminar(string idAEliminar) {

            Cliente clienteEliminado = new Cliente();

            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM tCliente WHERE uid = @uid; DELETE FROM tAluguer WHERE cliente = @uid;";
            comando.Parameters.AddWithValue("@uid", idAEliminar);
            telefone.SelectCommand = comando;
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            conexao.Dispose();

            return clienteEliminado;        //ou vem da BD ou é um novo pq o id não existe
        }
    }
}
