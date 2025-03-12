namespace Tablefy.Api.Entities
{
    public class ProductRecommendationsEntity
    {
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }

}
