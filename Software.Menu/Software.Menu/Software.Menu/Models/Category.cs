using System.Text.Json.Serialization;

namespace Software.Menu.Models
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Company Store { get; set; }
        public int IsDisplay { get; set; }
        public List<Product> Products { get; set; }

    }
}
