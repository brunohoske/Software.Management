using MySql.Data.MySqlClient;
using Restaurante.DAO;
using Restaurante.Data;
using Restaurante.Models;
using System.Data;


namespace Restaurante.UI
{
    public partial class UserMenager : BaseForm
    {
        public UserMenager()
        {
            InitializeComponent();
            LerDados();
            EstilizarGrid(dataGridView1);
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "Senha";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Administrador";
            dataGridView1.Columns[5].HeaderText = "Ativo";

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

                        DAOUsers daop = new DAOUsers();

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

            DAOUsers daoc = new DAOUsers();
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

            DAOUsers daoc = new DAOUsers();
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
