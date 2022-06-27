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
            txt_Nome.Focus();
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

        private void dgv_Dados_SelectionChanged(object sender, EventArgs e)
        {
            txt_Id.Text = dgv_Dados.CurrentRow.Cells[0].Value.ToString();
            txt_Nome.Text = dgv_Dados.CurrentRow.Cells[1].Value.ToString();
            txt_Numero.Text = dgv_Dados.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (txt_Nome.Text != "" && txt_Numero.Text != "")
            {
                Cliente cli = new Cliente();
                cli.Id = int.Parse(txt_Id.Text);
                cli.Nome = txt_Nome.Text;
                cli.Numero = txt_Numero.Text;
                Banco.Editar(cli);
            }
            else
            {
                MessageBox.Show("Preencha os campos");
                txt_Nome.Focus();

            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirma exclusão?", "Excluir", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Cliente cli = new Cliente();
                cli.Id = int.Parse(txt_Id.Text);
                Banco.Delete(cli);
                dgv_Dados.Rows.Remove(dgv_Dados.CurrentRow);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            txt_Id.Hide();
            lb_Id.Hide();
        }
    }
}
