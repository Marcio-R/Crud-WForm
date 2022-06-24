using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Teste
{
    class Banco
    {
        private static SqlConnection conexao;

        private static SqlConnection ConexaoBanco()
        {
            conexao = new SqlConnection("Data Source=DESKTOP-KB48KMI\\SQLEXPRESS;Initial Catalog=Crud;Integrated Security=True");
            conexao.Open();
            return conexao;
        }
    }
}
