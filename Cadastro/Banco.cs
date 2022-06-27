using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    class Banco
    {

        public static SqlConnection ConectaBanco()
        {
            SqlConnection conexao = new SqlConnection(" Data Source = DESKTOP-KB48KMI\\SQLEXPRESS;Initial Catalog = Crud; Integrated Security = True");
            conexao.Open();
            return conexao;
        }

        public static void NovoCliente(Cliente cliente)
        {
            try
            {
                var cmd = ConectaBanco().CreateCommand();
                cmd.CommandText = "INSERT INTO CLIENTES (NOME,NUMERO) VALUES (@NOME,@NUMERO)";
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                cmd.ExecuteNonQuery();
                ConectaBanco().Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ConectaBanco().Close();
            }
        }
        public static DataTable MostraTodos()
        {
            try
            {

                DataTable dt = new DataTable();
                var cmd = ConectaBanco().CreateCommand();
                cmd.CommandText = "SELECT * FROM CLIENTES";
                SqlDataAdapter adpter = new SqlDataAdapter(cmd.CommandText, ConectaBanco());
                adpter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
        public static DataTable ConsultaId(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                var cmd = ConectaBanco().CreateCommand();
                cmd.CommandText = $"SELECT * FROM CLIENTES WHERE ID = {id}";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, ConectaBanco());
                adapter.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public static void Editar(Cliente cli)
        {
            try
            {
                var cmd = ConectaBanco().CreateCommand();
                cmd.CommandText = $"UPDATE CLIENTES SET NOME = @Nome, NUMERO = @Numero WHERE ID = {cli.Id}";
                cmd.Parameters.AddWithValue("@Nome", cli.Nome);
                cmd.Parameters.AddWithValue("@Numero", cli.Numero);
                cmd.ExecuteNonQuery();
                ConectaBanco().Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void Delete(Cliente cli)
        {
            try
            {
                var cmd = ConectaBanco().CreateCommand();
                cmd.CommandText = $"DELETE FROM CLIENTES WHERE ID = {cli.Id}";
                cmd.ExecuteNonQuery();
                ConectaBanco().Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
