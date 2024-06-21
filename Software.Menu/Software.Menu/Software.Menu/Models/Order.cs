using MySqlX.XDevAPI.Relational;

namespace Software.Menu.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Company Store { get; set; }

        public Table Table { get; set; }
    }
}
