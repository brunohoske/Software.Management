namespace Tablefy.Api.Product.Models
{
    public class ProductCompanyModel
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool SaleProduct { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal ValueDiscount { get; set; }
    }
}