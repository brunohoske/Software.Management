namespace Tablefy.Api.Entities
{
    public class ProductIngredientsEntity
    {
        public int IngredientId { get; set; }
        public IngredientEntity Ingredient { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}