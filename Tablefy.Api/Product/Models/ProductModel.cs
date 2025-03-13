namespace Tablefy.Api.Product.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int CompaniesGroupId { get; set; }
        public string Description { get; set; }
        public float Kcal { get; set; }
        public string Image { get; set; }
        public string Barcode { get; set; }
        public bool IsCombo { get; set; }

        //public ICollection<ProductRecommendationsEntity> ProductRecommendations { get; set; } = new List<ProductRecommendationsEntity>();
        //public ICollection<ProductSidesEntity> ProductsSides { get; set; } = new List<ProductSidesEntity>();
        //public ICollection<SelectionGroupProductEntity> SelectionGroupProducts { get; set; } = new List<SelectionGroupProductEntity>();
        //public ICollection<ComboSelectionGroupEntity> ComboSelectionGroups { get; set; } = new List<ComboSelectionGroupEntity>();
        //public ICollection<CompanyProductEntity> CompanyProducts { get; set; } = new List<CompanyProductEntity>();
        //public ICollection<ProductIngredientsEntity> ProductIngredients { get; set; } = new List<ProductIngredientsEntity>();
    }
}