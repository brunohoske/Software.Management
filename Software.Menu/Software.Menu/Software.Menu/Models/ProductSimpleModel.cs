using Google.Protobuf.WellKnownTypes;

namespace Software.Menu.Models
{
    public class ProductSimpleModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float Kcal { get; set; }
        public string Image { get; set; }
        public string Barcode { get; set; }
        public bool IsCombo { get; set; }
        public int? CompanyId { get; set; }
        public int? ProductId { get; set; }
        public decimal Price { get; set; }
        public bool? Active { get; set; }
        public bool? SaleProduct { get; set; }
        public decimal? PercentageDiscount { get; set; }
        public decimal? ValueDiscount { get; set; }

        public List<ProductSimpleModel> comboProducts { get; set; }

        public decimal GetPrice()
        {
            if (ValueDiscount != 0)
            {
                return (decimal)(Price - ValueDiscount);
            }
            else if (PercentageDiscount != 0)
            {
                return (decimal)(Price - ((Price * PercentageDiscount) / 100));
            }
            return (decimal)(Price);

        }
    }
}
