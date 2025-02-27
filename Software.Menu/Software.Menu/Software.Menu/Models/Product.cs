using System.Text.Json.Serialization;

namespace Software.Menu.Models
{
    [JsonDerivedType(typeof(Combo), "combo")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
        public Category Category { get; set; }
        public Company Store { get; set; }
        public double Kcal { get; set; }
        public string Image { get; set; }
        public string BarCode { get; set; }
        public List<Product> Acompanhamentos { get; set; }
        [JsonPropertyName("categoriesRecommended")]
        public List<Category> CategoriesReccomended { get; set; }

    }
}
