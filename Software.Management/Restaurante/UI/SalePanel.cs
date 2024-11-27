using Restaurante.DAO;
using System.Data;
using System.Windows.Forms;


namespace Restaurante.UI
{
    public partial class SalePanel : BaseForm
    {
        public SalePanel()
        {
            InitializeComponent();
            LerDados();
            EstilizarGrid(dtgSalePanel);

            
            dtgSalePanel.Columns[0].HeaderText = "Código";
            dtgSalePanel.Columns[1].Visible = false;
            dtgSalePanel.Columns[2].HeaderText = "Total";
            dtgSalePanel.Columns[3].HeaderText = "Data";
            dtgSalePanel.Columns[4].HeaderText = "Mesa";
            dtgSalePanel.Columns[5].Visible = false;
            dtgSalePanel.Columns[6].HeaderText = "Status";

        }

        private void SalePanel_Load(object sender, EventArgs e)
        {
            
            lblQuant.Text = (dtgSalePanel.Rows.Count - 1).ToString();
            int total = 0;
            for (int i = 0; i < dtgSalePanel.Rows.Count; i++)
            {
                if (dtgSalePanel[2, i].Value != null)
                {
                    total += int.Parse(dtgSalePanel[2, i].Value.ToString());
                }

            }

            lblTotal.Text = total.ToString();
        }

        private void LerDados()
        {
            DAOOrder daoOrder = new DAOOrder();
            DataTable dt = new DataTable();
            dt = daoOrder.GetAll(dt);
            dtgSalePanel.DataSource = dt;

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
