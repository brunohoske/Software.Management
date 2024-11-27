using MySql.Data.MySqlClient;
using Restaurante.DAO;
using Restaurante.Data;
using Restaurante.Models;
using System.Data;


namespace Restaurante.UI
{
    public partial class DiscountManager : BaseForm
    {
        public DiscountManager()
        {
            InitializeComponent();
            LerProdutos();
            LerDados();
            EstilizarGrid(dataGridView1);
            EstilizarGrid(dataGridView2);


            dataGridView2.Columns[0].HeaderText = "Código-Produto";
            dataGridView2.Columns[1].HeaderText = "Nome";
            dataGridView2.Columns[2].HeaderText = "Descrição";
            dataGridView2.Columns[3].HeaderText = "Preço";
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].HeaderText = "Ativo";

            dataGridView1.Columns[0].HeaderText = "Código-Desconto";
            dataGridView1.Columns[1].HeaderText = "Porcentagem de desconto ";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Produto Relacionado";


        }

        private void BntInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPercentual.Text != "")
                {
                    double discountpercent = double.Parse(txtPercentual.Text);


                    if (discountpercent > 0)
                    {


                        Discount d = new Discount(discountpercent, "42591651000143", int.Parse(lblId.Text)); // Construtor


                        DAODiscount daod = new DAODiscount();

                        daod.Cadastrar(d);

                        LerDados();

                    }
                    else
                    {
                        MessageBox.Show("Valores negativos não são permitidos");
                    }

                }
                else
                {
                    MessageBox.Show("O campos é obrigatório");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("O percentual de desconto deve ser um número, e não pode ser vazio");
            }
        }
        private void LerDados()
        {

            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * from DISCOUNT order by ID_DISCOUNT";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            DataTable tbdiscount = new DataTable();
            adap.Fill(tbdiscount);
            dataGridView1.DataSource = tbdiscount;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
        }
        private void LerProdutos()
        {

            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * from products order by IDPRODUCT";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            DataTable tbProduto = new DataTable();
            adap.Fill(tbProduto);
            dataGridView2.DataSource = tbProduto;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView2.Rows[e.RowIndex];
            lblId.Text = drg.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView1.Rows[e.RowIndex];
            lblIdDiscount.Text = drg.Cells[0].Value.ToString();
            txtPercentual.Text = drg.Cells[1].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdDiscount.Text);
            double discountpercent = double.Parse(txtPercentual.Text);


            Discount disc = new Discount(discountpercent, "42591651000143", id) { Id = int.Parse(lblIdDiscount.Text) }; // Construtor

            DAODiscount daod = new DAODiscount();
            daod.Update(disc, double.Parse(txtPercentual.Text));
            LerDados();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblIdDiscount.Text);
            double discountpercent = double.Parse(txtPercentual.Text);

            Discount disc = new Discount(discountpercent, "42591651000143", id) { Id = int.Parse(lblIdDiscount.Text) }; // Construtor

            DAODiscount daod = new DAODiscount();
            const string message =
            "Deseja deletar?";
            const string caption = "Deletar";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                daod.Delete(disc);
                LerDados();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CouponManager couponManager = new CouponManager();
            couponManager.ShowDialog();
        }
    }
}
