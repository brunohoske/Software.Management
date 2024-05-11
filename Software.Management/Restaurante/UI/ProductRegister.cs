using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;
using System.Data;
using System.Windows.Forms;

namespace ProjetoDeSoftware
{
    public partial class ProductRegister : Form
    {
        public ProductRegister()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNome.Text != "" )
                {
                    string nome = txtNome.Text;
                    float preco = float.Parse(txtPreco.Text);
                    int qntd = int.Parse(txtQntd.Text);

                    if( preco > 0 && qntd > 0)
                    {
                        Produto p = new Produto(nome, preco, qntd); // Construtor

                        DAOProduto daop = new DAOProduto();

                        daop.Insert(p);

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
            catch(FormatException)
            {
                MessageBox.Show("Preço e quantidade devem ser números e devem ser preenchidos");
            }

           
        }

        private void Update_Click(object sender, EventArgs e)
        {


            int id = int.Parse(lblId.Text);
            string nome = txtNome.Text;
            float preco = float.Parse(txtPreco.Text);
            int qntd = int.Parse(txtQntd.Text);

            Produto al = new Produto(id, nome, preco, qntd); // Construtor

            DAOProduto daoc = new DAOProduto();
            daoc.Update(al);
            LerDados();

        }

        private void Dalete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);
            string nome = txtNome.Text;
            float preco = float.Parse(txtPreco.Text);
            int qntd = int.Parse(txtQntd.Text);

            Produto a = new Produto(id, nome, preco, qntd);

            DAOProduto daoc = new DAOProduto();
            const string message =
            "Deseja deletar?";
            const string caption = "Deletar";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                daoc.Delete(a);
                LerDados();
            }
        }

        private void LerDados()
        {

            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * from produtos order by idProdutos";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            DataTable tbProduto = new DataTable();
            adap.Fill(tbProduto);
            dataGridView1.DataSource = tbProduto;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dataGridView1.Rows[e.RowIndex];
            lblId.Text = drg.Cells[0].Value.ToString();
            txtNome.Text = drg.Cells[1].Value.ToString();
            txtPreco.Text = drg.Cells[2].Value.ToString();
            txtQntd.Text = drg.Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LerDados();
        }
    }
}
