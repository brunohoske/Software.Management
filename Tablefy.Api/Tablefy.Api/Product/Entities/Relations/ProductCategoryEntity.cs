using Tablefy.Api.Category;

namespace Tablefy.Api.Product.Entities.Relations
{
    public class ProductCategoryEntity
    {
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }

}
