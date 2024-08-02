using Restaurante.BLL;
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
    public partial class SalePanel : Form
    {
        public SalePanel()
        {
            InitializeComponent();
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

    }
}
