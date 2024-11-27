using Restaurante.DAO;
using Restaurante.Models;

namespace Restaurante.UI
{
    public partial class FeedbackUI : BaseForm
    {
        public FeedbackUI()
        {
            InitializeComponent();
            LerFeedbacks();
            EstilizarGrid(dtgFeedback);
            EstilizarGrid(dtgOrders);


            dtgFeedback.Columns[0].HeaderText = "Identificado do feedback";
            dtgFeedback.Columns[1].HeaderText = "Produto comprado";
            dtgFeedback.Columns[2].HeaderText = "Descrição";

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


            dtgOrders.Columns[0].HeaderText = "Número do pedido";
            dtgOrders.Columns[1].HeaderText = "Produto comprado";
            dtgOrders.Columns[2].HeaderText = "Descrição";
            dtgOrders.Columns[3].HeaderText = "Valor do pedido";
        }
    }
}
