
namespace SystemManagement.Models
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Store Store { get; set; }
        public int IsDisplay { get; set; }
        public List<Product> Products { get; set; }
        //public List<Combo> Combos { get; set; }

    }
}
