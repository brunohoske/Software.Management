using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    internal class Discount
    { 

        public int Id { get; set; }

        public double DiscountPercent { get; set; }

        public string Cnpj { get; set; }

        public int Id_Produto { get; set; }



        public Discount(double discountpercent, string cnpj, int idproduto)
        {
            DiscountPercent = discountpercent;
            Cnpj = cnpj;
            Id_Produto = idproduto;
        }
    }
}
