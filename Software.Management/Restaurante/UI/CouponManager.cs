using MySql.Data.MySqlClient;
using Restaurante.DAO;
using Restaurante.Data;
using Restaurante.Models;
using System.Data;
using System.Windows.Forms;

namespace Restaurante.UI
{
    public partial class CouponManager : BaseForm
    {
        public CouponManager()
        {
            InitializeComponent();
            LerDados();
            EstilizarGrid(dtgCoupon);

            dtgCoupon.Columns[0].HeaderText = "Identificador";
            dtgCoupon.Columns[1].HeaderText = "Código do cupom";
            dtgCoupon.Columns[2].HeaderText = "% de desconto";
            dtgCoupon.Columns[3].HeaderText = "Ativo";
        }

        private void LerDados()
        {
            MySqlConnection conexao = null;
            FabricaConexao f = new FabricaConexao();
            conexao = f.Conectar();
            string sql = "SELECT * from COUPON order by COUPONID";
            MySqlDataAdapter adap = new MySqlDataAdapter(sql, conexao);
            DataTable tbdiscount = new DataTable();
            adap.Fill(tbdiscount);
            dtgCoupon.DataSource = tbdiscount;
            dtgCoupon.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtgCoupon.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dtgCoupon.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
            conexao.Close();
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
                        if (txtCode.Text != "" || txtCode.Text != string.Empty)
                        {
                            Coupon coupon = new Coupon()
                            {
                                Code = txtCode.Text,
                                Discount = double.Parse(txtPercentual.Text),
                                Active = cbActive.Checked
                            };


                            DAOCoupon daoCoupon = new DAOCoupon();

                            daoCoupon.Cadastrar(coupon);

                            LerDados();
                        }
                        else
                        {
                            MessageBox.Show("Preencha o código do cupom");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Valores negativos não são permitidos");
                    }

                }
                else
                {
                    MessageBox.Show("Os campos são obrigatórios");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("O percentual de desconto deve ser um número, e não pode ser vazio");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);

            Coupon coupon = new Coupon()
            {
                CouponId = id,
                Code = txtCode.Text,
                Discount = double.Parse(txtPercentual.Text),
                Active = cbActive.Checked

            };

            DAOCoupon daoCoupon = new DAOCoupon();
            daoCoupon.Update(coupon);
            LerDados();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblId.Text);

            Coupon coupon = new Coupon()
            {
                CouponId = id,
                Code = txtCode.Text,
                Discount = double.Parse(txtPercentual.Text),
                Active = cbActive.Checked
            };

            DAOCoupon daoCoupon = new DAOCoupon();
            const string message =
            "Deseja deletar?";
            const string caption = "Deletar";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                daoCoupon.Delete(coupon);
                LerDados();
            }
        }

        private void dtgCoupon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dtgCoupon.Rows[e.RowIndex];
            lblId.Text = drg.Cells[0].Value.ToString();
            txtCode.Text = drg.Cells[1].Value.ToString();
            txtPercentual.Text = drg.Cells[2].Value.ToString();
            cbActive.Checked = int.Parse(drg.Cells[3].Value.ToString()) == 1 ? true : false;
        }
    }
}
