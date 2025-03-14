using Tablefy.Api.Company;
using Tablefy.Api.Product.Entities.Relations;

namespace Tablefy.Api.Product.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CompaniesGroupId { get; set; }
        public CompaniesGroupEntity CompaniesGroup { get; set; }
        public string Description { get; set; }
        public float Kcal { get; set; }
        public string Image { get; set; }
        public string Barcode { get; set; }
        public bool IsCombo { get; set; }

        public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();
        public ICollection<ProductRecommendationsEntity> ProductRecommendations { get; set; } = new List<ProductRecommendationsEntity>();
        public ICollection<ProductSidesEntity> ProductsSides { get; set; } = new List<ProductSidesEntity>();
        public ICollection<SelectionGroupProductEntity> SelectionGroupProducts { get; set; } = new List<SelectionGroupProductEntity>();
        public ICollection<ProductCompanyEntity> CompanyProducts { get; set; } = new List<ProductCompanyEntity>();
        public ICollection<ProductIngredientsEntity> ProductIngredients { get; set; } = new List<ProductIngredientsEntity>();
        public ICollection<ComboProductsEntity> ComboProducts { get; set; } = new List<ComboProductsEntity>();
    }
}