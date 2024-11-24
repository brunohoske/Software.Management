using Restaurante.BLL;
using System.Data;
using System.Windows.Forms;


namespace Restaurante.UI
{
    public partial class SalePanel : BaseForm
    {
        public SalePanel()
        {
            InitializeComponent();
            EstilizarGrid(dtgSalePanel);
        }

        private void SalePanel_Load(object sender, EventArgs e)
        {
            LerDados();
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
