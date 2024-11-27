using MySql.Data.MySqlClient;
using Restaurante.DAO;
using Restaurante.Data;
using Restaurante.Models;
using System.Data;


namespace Restaurante.UI
{
    public partial class CheckRegister : BaseForm
    {
        public CheckRegister()
        {
            InitializeComponent();
            EstilizarGrid(dataGridView1);


        }

        private void BntInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumMesa.Text != "")
                {
                    double numeroMesa = double.Parse(txtNumMesa.Text);

                    if (numeroMesa > 0)
                    {
                        Check c = new Check(numeroMesa); // Construtor


                        DAOCheck daoc = new DAOCheck();

                        daoc.Cadastrar(c);

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
                MessageBox.Show("Número da mesa e CNPJ devem ser respectivamente um número e um texto, e não podem ser vazios");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            double numeroMesa = double.Parse(txtNumMesa.Text);

            Check ch = new Check(int.Parse(lblnumMesa.Text));

            DAOCheck daoc = new DAOCheck();
            daoc.Update(ch, numeroMesa);
            LerDados();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            double numeroMesa = double.Parse(txtNumMesa.Text);

            Check che = new Check(numeroMesa);

            DAOCheck daoc = new DAOCheck();
            const string message =
            "Deseja deletar?";
            const string caption = "Deletar";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                daoc.Delete(che);
                LerDados();
            }
        }

        private void LerDados()
        {

            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * from CHECKS order by CHECK_NUMBER";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            DataTable tbProduto = new DataTable();
            adap.Fill(tbProduto);
            dataGridView1.DataSource = tbProduto;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView1.Rows[e.RowIndex];
            lblnumMesa.Text = drg.Cells[0].Value.ToString();
            txtNumMesa.Text = drg.Cells[0].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckRegister_Load(object sender, EventArgs e)
        {
            LerDados();
            dataGridView1.Columns[0].HeaderText = "Número da mesa";
            dataGridView1.Columns[1].Visible = false;
        }

        private void btnGerarQR_Click(object sender, EventArgs e)
        {
            QrCodeUI qr = new QrCodeUI($@"https://localhost:7124/mcdonalds/cardapio/m{lblnumMesa.Text}");
            qr.Show();
            

        }

    }
}
