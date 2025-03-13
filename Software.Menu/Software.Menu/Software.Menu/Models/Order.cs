using MySqlX.XDevAPI.Relational;

namespace Software.Menu.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Company Store { get; set; }
        public Table Table { get; set; }
        public int Status { get; set; }
    }
}
