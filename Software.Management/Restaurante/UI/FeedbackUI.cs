
using Restaurante.BLL;
using Restaurante.DTO;
using System.Windows.Forms;


namespace Restaurante.UI
{
    public partial class FeedbackUI : BaseForm
    {
        public FeedbackUI()
        {
            InitializeComponent();
            EstilizarGrid(dtgFeedback);
            EstilizarGrid(dtgOrders);
        }
        private void LerFeedbacks()
        {
            DAOFeedback daoFeedback = new DAOFeedback();
            var tbFeedback = daoFeedback.ReadFeedbacks();
            dtgFeedback.DataSource = tbFeedback;
            dtgFeedback.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtgFeedback.AlternatingRowsDefaultCellStyle.ForeColor = Color.Gray;
            dtgFeedback.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14);
        }
        private void FeedbackUI_Load(object sender, EventArgs e)
        {
            LerFeedbacks();
        }

        private void dtgFeedback_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow drg = dtgFeedback.Rows[e.RowIndex];
            lblIdOrder.Text = drg.Cells[1].Value.ToString();
            LerOrder(int.Parse(lblIdOrder.Text));


        }

        private void LerOrder(int idOrder)
        {
            DAOOrder daoOrder = new DAOOrder();
            var tbOrder = daoOrder.GetProducts(new Order() { Id = int.Parse(lblIdOrder.Text) });
            dtgOrders.DataSource = tbOrder;
        }
    }
}
