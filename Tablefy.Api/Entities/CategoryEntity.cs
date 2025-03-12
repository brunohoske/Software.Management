namespace Tablefy.Api.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DisplayMainPage { get; set; }

        public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();
        public ICollection<ProductRecommendationsEntity> ProductRecommendations { get; set; } = new List<ProductRecommendationsEntity>();
    }
}