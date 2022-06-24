using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            if (txt_Nome.Text != "" && txt_Numero.Text != "")
            {
                Cliente cli = new Cliente();
                cli.Nome = txt_Nome.Text;
                cli.Numero = txt_Numero.Text;
                Banco.NovoCliente(cli);
            }
            else
            {
                MessageBox.Show("Preencha os campos");
                txt_Nome.Focus();

            }
        }

        private void btn_Exibir_Click(object sender, EventArgs e)
        {
            dgv_Dados.DataSource = Banco.MostraTodos();
        }

        private void btn_Conslta_Click(object sender, EventArgs e)
        {
            dgv_Dados.DataSource = Banco.ConsultaId(txt_Id.Text);
        }
    }
}
