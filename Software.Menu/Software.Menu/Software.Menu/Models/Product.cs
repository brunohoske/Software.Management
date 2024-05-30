namespace Software.Menu.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Company Store { get; set; }

    }
}
