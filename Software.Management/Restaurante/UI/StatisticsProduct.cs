using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurante.BLL;
using Restaurante.DAL;
using Restaurante.DTO;

namespace Restaurante.UI
{
    public partial class StatisticsProduct : Form
    {
        public Produto produto { get; set; }
        DAOProduto dp = new DAOProduto();

        public StatisticsProduct(Produto p)
        {
            InitializeComponent();
            produto = p;
        }

        private void StatisticsProduct_Load(object sender, EventArgs e)
        {
            ExibirPedidosNoDataGridView(produto.Id, dtProduct);
        }

        public void ExibirPedidosNoDataGridView(int produtoId, DataGridView dtProduct)
        {
            DataTable pedidos = dp.GetPedidosByProduto(produtoId);
            dtProduct.DataSource = pedidos;
        }
        
        public void ExibirEstatisticas()
        {
            decimal totalReceita = 0;
            int totalVendas = 0;

            foreach (DataGridViewRow row in dtProduct.Rows)
            {
                if (row.Cells["quantity"].Value != null && row.Cells["unit_price"].Value != null)
                {
                    int quantidade = Convert.ToInt32(row.Cells["quantity"].Value);
                    decimal preco = Convert.ToDecimal(row.Cells["unit_price"].Value);

                    totalReceita += quantidade * preco;
                }
            }

            totalVendas = dtProduct.Rows.Count;

            lblTotalR.Text = $"{totalReceita}";
            lblTotalV.Text = $"{totalVendas}";
        }
    }
}


