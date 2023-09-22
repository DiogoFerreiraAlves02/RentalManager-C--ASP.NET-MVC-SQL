using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models.Helpers {
    public class AluguerHelperCRUD {
        private string _conexaoBD;

        public AluguerHelperCRUD(string conexao) {
            _conexaoBD = conexao;
        }

        public List<Aluguer> list() {

            List<Aluguer> listaSaida = new List<Aluguer>();

            DataTable dtAlugueres = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tAluguer WHERE estado != 0 ORDER BY dataLimite ASC";
            telefone.SelectCommand = comando;
            telefone.Fill(dtAlugueres);
            conexao.Close();
            conexao.Dispose();
            //Transformar um conjunto de registos num conjunto de objetos
            foreach (DataRow linha in dtAlugueres.Rows) {
                Aluguer aluguer = new Aluguer();
                aluguer.Id = Guid.Parse(linha["uid"].ToString());
                aluguer.Cliente.Id = Guid.Parse(linha["cliente"].ToString());
                aluguer.Funcionario.Id = Guid.Parse(linha["funcionario"].ToString());
                aluguer.Produto.Id = Guid.Parse(linha["produto"].ToString());
                aluguer.PrecoDiario = Convert.ToDecimal(linha["precoDiario"]);
                aluguer.Dias = Convert.ToInt32(linha["dias"]);
                aluguer.PrecoTotal = Convert.ToDecimal(linha["precoTotal"]);
                aluguer.Caucao = Convert.ToDecimal(linha["caucao"]);
                aluguer.DataAluguer = Convert.ToDateTime(linha["dataAluguer"]);
                aluguer.DataLimite = Convert.ToDateTime(linha["dataLimite"]);
                aluguer.Estado = (Aluguer.TipoEstado)Convert.ToInt32(linha["estado"]);
                listaSaida.Add(aluguer);
            }
            return listaSaida;
        }

        public List<Aluguer> listDevolvidos() {

            List<Aluguer> listaSaida = new List<Aluguer>();

            DataTable dtAlugueres = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tAluguer WHERE estado = 0 ORDER BY dataLimite ASC ";
            telefone.SelectCommand = comando;
            telefone.Fill(dtAlugueres);
            conexao.Close();
            conexao.Dispose();
            //Transformar um conjunto de registos num conjunto de objetos
            foreach (DataRow linha in dtAlugueres.Rows) {
                Aluguer aluguer = new Aluguer();
                aluguer.Id = Guid.Parse(linha["uid"].ToString());
                aluguer.Cliente.Id = Guid.Parse(linha["cliente"].ToString());
                aluguer.Funcionario.Id = Guid.Parse(linha["funcionario"].ToString());
                aluguer.Produto.Id = Guid.Parse(linha["produto"].ToString());
                aluguer.PrecoDiario = Convert.ToDecimal(linha["precoDiario"]);
                aluguer.Dias = Convert.ToInt32(linha["dias"]);
                aluguer.PrecoTotal = Convert.ToDecimal(linha["precoTotal"]);
                aluguer.Caucao = Convert.ToDecimal(linha["caucao"]);
                aluguer.DataAluguer = Convert.ToDateTime(linha["dataAluguer"]);
                aluguer.DataLimite = Convert.ToDateTime(linha["dataLimite"]);
                aluguer.Estado = (Aluguer.TipoEstado)Convert.ToInt32(linha["estado"]);
                listaSaida.Add(aluguer);
            }
            return listaSaida;
        }

        public Guid insert(Aluguer aluguer) {
            Guid idReturned = Guid.Empty;
            if (aluguer.Id == Guid.Empty) {
                aluguer.Id = Guid.NewGuid();
                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO tAluguer (uid, cliente, funcionario, produto, precoDiario, dias, precoTotal, caucao, dataAluguer, dataLimite, estado) " +
                                            " VALUES (@uid, @cliente, @funcionario, @produto, @precoDiario, @dias, @precoTotal, @caucao, @dataAluguer, @dataLimite, @estado)";
                    comando.Parameters.AddWithValue("@uid", aluguer.Id);
                    comando.Parameters.AddWithValue("@cliente", aluguer.Cliente.Id);
                    comando.Parameters.AddWithValue("@funcionario", aluguer.Funcionario.Id);
                    comando.Parameters.AddWithValue("@produto", aluguer.Produto.Id);
                    comando.Parameters.AddWithValue("@precoDiario", aluguer.PrecoDiario);
                    comando.Parameters.AddWithValue("@dias", aluguer.Dias);
                    comando.Parameters.AddWithValue("@precoTotal", aluguer.PrecoTotal);
                    comando.Parameters.AddWithValue("@caucao", aluguer.Caucao);
                    comando.Parameters.AddWithValue("@dataAluguer", aluguer.DataAluguer);
                    comando.Parameters.AddWithValue("@dataLimite", aluguer.DataLimite);
                    comando.Parameters.AddWithValue("@estado", aluguer.Estado);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = aluguer.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }

        public Aluguer read(string idAPesquisar) {

            Aluguer aluguerSaida = new Aluguer();

            DataTable dtAlugueres = new DataTable();
            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM tAluguer WHERE uid = @uid";
            comando.Parameters.AddWithValue("@uid", idAPesquisar);
            telefone.SelectCommand = comando;
            telefone.Fill(dtAlugueres);
            conexao.Close();
            conexao.Dispose();
            if (dtAlugueres.Rows.Count == 1) {
                DataRow linha = dtAlugueres.Rows[0];     //e unica
                aluguerSaida.Id = Guid.Parse(linha["uid"].ToString());
                aluguerSaida.Cliente.Id = Guid.Parse(linha["cliente"].ToString());
                aluguerSaida.Funcionario.Id = Guid.Parse(linha["funcionario"].ToString());
                aluguerSaida.Produto.Id = Guid.Parse(linha["produto"].ToString());
                aluguerSaida.PrecoDiario = Convert.ToDecimal(linha["precoDiario"]);
                aluguerSaida.Dias = Convert.ToInt32(linha["dias"]);
                aluguerSaida.PrecoTotal = Convert.ToDecimal(linha["precoTotal"]);
                aluguerSaida.Caucao = Convert.ToDecimal(linha["caucao"]);
                aluguerSaida.DataAluguer = Convert.ToDateTime(linha["dataAluguer"]);
                aluguerSaida.DataLimite = Convert.ToDateTime(linha["dataLimite"]);
                aluguerSaida.Estado = (Aluguer.TipoEstado)Convert.ToInt32(linha["estado"]);
            }
            return aluguerSaida;        //ou vem da BD ou é um novo pq o id não existe
        }

        public Aluguer eliminar(string idAEliminar) {

            Aluguer aluguerEliminado = new Aluguer();

            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlConnection conexao = new SqlConnection(_conexaoBD);
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexao;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM tAluguer WHERE uid = @uid";
            comando.Parameters.AddWithValue("@uid", idAEliminar);
            telefone.SelectCommand = comando;
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            conexao.Dispose();

            return aluguerEliminado;        //ou vem da BD ou é um novo pq o id não existe
        }

        public Guid update(Aluguer aluguer) {
            Guid idReturned = Guid.Empty;
            if (aluguer.Id != Guid.Empty) {

                try {
                    SqlConnection conexao = new SqlConnection(_conexaoBD);
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexao;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "UPDATE tAluguer SET cliente = @cliente, funcionario = @funcionario," +
                        "produto = @produto, precoDiario = @precoDiario, dias = @dias, precoTotal = @precoTotal," +
                        "caucao = @caucao, dataAluguer = @dataAluguer, dataLimite = @dataLimite, estado = @estado WHERE uid = @uid";

                    comando.Parameters.AddWithValue("@uid", aluguer.Id);
                    comando.Parameters.AddWithValue("@cliente", aluguer.Cliente.Id);
                    comando.Parameters.AddWithValue("@funcionario", aluguer.Funcionario.Id);
                    comando.Parameters.AddWithValue("@produto", aluguer.Produto.Id);
                    comando.Parameters.AddWithValue("@precoDiario", aluguer.PrecoDiario);
                    comando.Parameters.AddWithValue("@dias", aluguer.Dias);
                    comando.Parameters.AddWithValue("@precoTotal", aluguer.PrecoTotal);
                    comando.Parameters.AddWithValue("@caucao", aluguer.Caucao);
                    comando.Parameters.AddWithValue("@dataAluguer", aluguer.DataAluguer);
                    comando.Parameters.AddWithValue("@dataLimite", aluguer.DataLimite);
                    comando.Parameters.AddWithValue("@estado", aluguer.Estado);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    conexao.Dispose();
                    idReturned = aluguer.Id;
                }
                catch {
                    idReturned = Guid.Empty;
                }
            }
            return idReturned;
        }
    }
}
