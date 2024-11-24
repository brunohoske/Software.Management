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
    public partial class StatisticsProduct : BaseForm
    {
        public Produto produto { get; set; }
        DAOProduto dp = new DAOProduto();

        public StatisticsProduct(Produto p)
        {
            InitializeComponent();
            produto = p;
            EstilizarGrid(dtProduct);
        }

        private void StatisticsProduct_Load(object sender, EventArgs e)
        {
            ExibirPedidosNoDataGridView(produto.Id, dtProduct);
            ExibirEstatisticas();
            lblProduct.Text = $"PRODUTO SELECIONADO: {produto.Nome}";
        }

        public void ExibirPedidosNoDataGridView(int produtoId, DataGridView dtProduct)
        {
            DataTable pedidos = dp.GetPedidosByProduto(produtoId);
            dtProduct.DataSource = pedidos;
        }
        
        public void ExibirEstatisticas()
        {
            double totalReceita = (dtProduct.RowCount - 1) * produto.Preco;
            double totalVendas = 0;
            int quantidade = dtProduct.RowCount - 1;

            foreach (DataGridViewRow row in dtProduct.Rows)
            {
                
                if (row.Cells["total"].Value != null)
                {
                    // Tenta converter o valor da célula para double e adiciona ao total
                    double value;
                    if (double.TryParse(row.Cells["total"].Value.ToString(), out value))
                    {
                        totalVendas += value;
                    }
                }
            }
            lblTotalPerProduto.Text = $"{totalReceita.ToString("F2")}";
            lblTotal.Text = $"{totalVendas.ToString("F2")}";
            lblQuant.Text = quantidade.ToString();
        }
    }
}


