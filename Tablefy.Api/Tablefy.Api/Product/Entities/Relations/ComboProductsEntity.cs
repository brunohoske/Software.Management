using Tablefy.Api.Ingredient;

namespace Tablefy.Api.Product.Entities.Relations
{
    public class ComboProductsEntity
    {
        public int ComboId { get; set; }
        public ProductEntity Combo { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
