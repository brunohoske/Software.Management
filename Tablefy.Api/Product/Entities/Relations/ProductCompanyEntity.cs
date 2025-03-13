using Tablefy.Api.Company;

namespace Tablefy.Api.Product.Entities.Relations
{
    public class ProductCompanyEntity
    {
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool SaleProduct { get; set; }
        public decimal PercentageDiscount { get; set; }
        public decimal ValueDiscount { get; set; }
    }
}