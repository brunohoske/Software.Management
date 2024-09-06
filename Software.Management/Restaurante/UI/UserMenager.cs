using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.UI
{
    public partial class UserMenager : Form
    {
        public UserMenager()
        {
            InitializeComponent();
            LerDados();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserMenager_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView1.Rows[e.RowIndex];


            lblId.Text = drg.Cells[0].Value.ToString();
            txtNome.Text = drg.Cells[1].Value.ToString();
            txtSenha.Text = drg.Cells[2].Value.ToString();
            int check = int.Parse(drg.Cells[4].Value.ToString());
            if (check == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            cbAtivo.Checked = int.Parse(drg.Cells[5].Value.ToString()) == 1 ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    string senha = txtSenha.Text;
                    bool adm = checkBox1.Checked;
                    bool ativo = cbAtivo.Checked;

                    if (senha != "")
                    {
                        Users u = new Users(nome, senha, adm) { IsActive = ativo}; // Construtor

                        DALUsers daop = new DALUsers();

                        daop.Insert(u);

                        LerDados();
                    }
                    else
                    {
                        MessageBox.Show("Valores negativos não são permitidos");
                    }

                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Preço e quantidade devem ser números e devem ser preenchidos");
            }


        }

        private void LerDados()
        {

            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * from Users order by iduser";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            DataTable tbProduto = new DataTable();
            adap.Fill(tbProduto);
            dataGridView1.DataSource = tbProduto;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            int id = int.Parse(lblId.Text);
            string nome = txtNome.Text;
            string senha = txtSenha.Text;
            bool adm = checkBox1.Checked;
            bool ativo = cbAtivo.Checked;

            Users al = new Users(id, nome, senha, adm) { IsActive = ativo }; // Construtor

            DALUsers daoc = new DALUsers();
            daoc.Update(al);
            LerDados();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id = int.Parse(lblId.Text);
            string nome = txtNome.Text;
            string senha = txtSenha.Text;
            bool adm = checkBox1.Checked;

            Users u = new Users(id, nome, senha, adm); ;

            DALUsers daoc = new DALUsers();
            const string message =
            "Deseja deletar?";
            const string caption = "Deletar";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                daoc.Delete(u);
                LerDados();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void cbAtivo_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
