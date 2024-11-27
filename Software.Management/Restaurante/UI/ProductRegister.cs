using MySql.Data.MySqlClient;
using Restaurante.DAO;
using Restaurante.Data;
using Restaurante.Models;
using Restaurante.UI;
using System.Data;

namespace ProjetoDeSoftware
{
    public partial class ProductRegister : BaseForm
    {
        public ProductRegister()
        {
            InitializeComponent();
         

            EstilizarGrid(dataGridView1);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteColumn",
                HeaderText = "Excluir",
                Text = "🗑️", // Ícone ou texto para o botão
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat // Estilo moderno do botão
            };
           
            // Adiciona ao grid
            dataGridView1.Columns.Add(deleteButtonColumn);

            LerDados();
            dataGridView1.Columns[0].Width = 75;
            dataGridView1.Columns[1].HeaderText = "Código";
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].HeaderText = "Nome";
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].HeaderText = "Descrição";
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].HeaderText = "Preço";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Ativo";


        }

       





        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    float preco = float.Parse(txtPreco.Text);
                    string desc = txtDescription.Text;
                    bool ativo = cbAtivo.Checked;

                    if (preco > 0)
                    {
                        Produto p = new Produto(nome, preco, desc) { IsActive = ativo };

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
            catch (FormatException)
            {
                MessageBox.Show("Preço e quantidade devem ser números e devem ser preenchidos");
            }


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que a linha é válida
            {
                // Pega a linha atual
                var row = dataGridView1.Rows[e.RowIndex];

                // Extrai os dados da linha
                var idProduto = int.Parse(row.Cells["IDPRODUTO"].Value?.ToString()); // ID único do produto
                var nomeProduto = row.Cells["PRODUCT"].Value?.ToString();
                var descricao = row.Cells["DESCRIP"].Value?.ToString();
                var preco = float.Parse(row.Cells["PRICE"].Value?.ToString());
                var cnpj = row.Cells["CNPJ"].Value?.ToString();
                var ativo = (row.Cells["ACTIVE"].Value?.ToString() == "1" ? true : false);

                // Atualize no banco de dados
                Produto al = new Produto(idProduto, nomeProduto, preco, descricao) { IsActive = ativo }; // Construtor
                DAOProduto daoc = new DAOProduto();
                daoc.Update(al);
                LerDados();
            }
        }


        private void Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);
            string nome = txtNome.Text;
            float preco = float.Parse(txtPreco.Text);
            string desc = txtDescription.Text;
            bool ativo = cbAtivo.Checked;
            Produto al = new Produto(id, nome, preco, desc) { IsActive = ativo }; // Construtor

            DAOProduto daoc = new DAOProduto();
            daoc.Update(al);
            LerDados();

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);
            string nome = txtNome.Text;
            float preco = float.Parse(txtPreco.Text);
            string desc = txtDescription.Text;

            Produto a = new Produto(id, nome, preco, desc);

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
            string sql = "SELECT * from products order by IDPRODUCT";
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
            lblId.Text = drg.Cells[1].Value.ToString();
            txtNome.Text = drg.Cells[2].Value.ToString();
            txtDescription.Text = drg.Cells[3].Value.ToString();
            txtPreco.Text = drg.Cells[4].Value.ToString();

            cbAtivo.Checked = int.Parse(drg.Cells[6].Value.ToString()) == 1 ? true : false;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                // Confirmação da exclusão
                var confirmResult = MessageBox.Show(
                    "Tem certeza que deseja excluir este registro?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Obtém o ID do registro a ser excluído
                    var idProduto = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["IDPRODUCT"].Value?.ToString());

                    if (!string.IsNullOrEmpty(idProduto.ToString()))
                    {
                        // Chama o método para remover do banco
                        DAOProduto daoc = new DAOProduto();
                        daoc.Delete(new Produto() { Id = idProduto});

                        // Remove a linha do grid
                        dataGridView1.Rows.RemoveAt(e.RowIndex);

                        MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbAtivo_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DAOProduto dp = new DAOProduto();
            Produto p = new Produto();
            int productId;

            if (int.TryParse(lblId.Text, out productId))
            {
                p = dp.FindProduct(productId);
                StatisticsProduct st = new StatisticsProduct(p);
                st.Show();
            }
            else
            {
                MessageBox.Show("Invalid product ID. Please enter a valid number.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
