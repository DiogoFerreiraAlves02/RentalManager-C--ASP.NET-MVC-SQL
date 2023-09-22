using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models.Helpers {
    public class ProdutoHelperCRUD {
        private string _conexaoBD;

        public ProdutoHelperCRUD(string conexao) {
            _conexaoBD = conexao;
        }

        public List<Produto> list() {

            List<Produto> listaSaida = new List<Produto>();

            DataTable dtProdutos = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tProduto ORDER BY designacao ASC";
            telefone.SelectCommand = comando;
            telefone.Fill(dtProdutos);
            conexao.Close();
            conexao.Dispose();
            //Transformar um conjunto de registos num conjunto de objetos
            foreach (DataRow linha in dtProdutos.Rows) {
                Produto produto = new Produto();
                produto.Id = Guid.Parse(linha["uid"].ToString());
                produto.Designacao = linha["designacao"].ToString();
                listaSaida.Add(produto);
            }
            return listaSaida;
        }

        public Guid insert(Produto produto) {
            Guid idReturned = Guid.Empty;
            if (produto.Id == Guid.Empty) {
                produto.Id = Guid.NewGuid();
                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO tProduto(uid, designacao) VALUES(@uid, @designacao)";
                    comando.Parameters.AddWithValue("@uid", produto.Id);
                    comando.Parameters.AddWithValue("@designacao", produto.Designacao);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = produto.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }

        public Produto read(string idAPesquisar) {

            Produto produtoSaida = new Produto();

            DataTable dtProdutos = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tProduto WHERE uid = @uid";
            comando.Parameters.AddWithValue("@uid", idAPesquisar);
            telefone.SelectCommand = comando;
            telefone.Fill(dtProdutos);
            conexao.Close();
            conexao.Dispose();
            if (dtProdutos.Rows.Count == 1) {
                DataRow linha = dtProdutos.Rows[0];     //e unica
                produtoSaida.Id = Guid.Parse(linha["uid"].ToString());
                produtoSaida.Designacao = linha["designacao"].ToString();
            }
            return produtoSaida;        //ou vem da BD ou é um novo pq o id não existe
        }

        public Guid update(Produto produto) {
            Guid idReturned = Guid.Empty;
            if (produto.Id != Guid.Empty) {

                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE tProduto SET designacao = @designacao WHERE uid = @uid";
                                            
                    comando.Parameters.AddWithValue("@uid", produto.Id);
                    comando.Parameters.AddWithValue("@designacao", produto.Designacao);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = produto.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }

        public Produto eliminar(string idAEliminar) {

            Produto produtoEliminado = new Produto();

            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM tProduto WHERE uid = @uid; DELETE FROM tAluguer WHERE produto = @uid;";
            comando.Parameters.AddWithValue("@uid", idAEliminar);
            telefone.SelectCommand = comando;
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            conexao.Dispose();

            return produtoEliminado;        //ou vem da BD ou é um novo pq o id não existe
        }

    }
}
