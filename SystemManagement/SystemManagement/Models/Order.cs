namespace SystemManagement.Models
{
    public class Order
    {

        public List<Product> Products { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Store Store { get; set; }

        public Table Table { get; set; }


    }
}
