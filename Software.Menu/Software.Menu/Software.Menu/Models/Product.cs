namespace Software.Menu.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public Category Category { get; set; }
        public Company Store { get; set; }
        public double Kcal { get; set; }
        public string Image { get; set; }

    }
}
