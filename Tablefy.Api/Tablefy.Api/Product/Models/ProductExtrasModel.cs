using Tablefy.Api.Ingredient;

namespace Tablefy.Api.Product.Models
{
    public class ProductExtrasModel
    {
        public ICollection<ProductSimpleModel> Recommendations { get; set; } = new List<ProductSimpleModel>();
        public ICollection<ProductSideModel> Sides { get; set; } = new List<ProductSideModel>();
        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public ICollection<ProductSimpleModel> ComboProducts { get; set; } = new List<ProductSimpleModel>();
        public ICollection<SelectionGroupModel> SelectionGroups { get; set; } = new List<SelectionGroupModel>();
    }
}