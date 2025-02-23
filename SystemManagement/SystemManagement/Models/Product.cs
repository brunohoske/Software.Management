using System.Text.Json.Serialization;
using SystemManagement.Dao;

namespace SystemManagement.Models
{
    [JsonDerivedType(typeof(Combo), "combo")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Category Category { get; set; }
        public Store Store { get; set; }
        public double Kcal { get; set; }
        public string BarCode { get; set; }
        public string Image { get; set; }   
        public List<Category> CategoriesRecommended { get; set; }
        public List<Product> Acompanhamentos { get; set; }

    }
}
