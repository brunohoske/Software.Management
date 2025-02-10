using Software.Menu.Models;

namespace Software.Menu.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public Category Category { get; set; }
        public Company Store { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }

    }
}
