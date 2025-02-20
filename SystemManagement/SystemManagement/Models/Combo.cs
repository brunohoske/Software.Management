namespace SystemManagement.Models
{
    public class Combo
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public double Kcal { get; set; }
        public string BarCode { get; set; }
        public string Image { get; set; }
        public Store Store { get; set; }
        public List<Product> Products { get; set; }
        public List<Grupo> Groups { get; set; }

    }
}
