using MySqlX.XDevAPI.Relational;

namespace Software.Menu.Models
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Company store { get; set; }

        public int Table { get; set; }
    }
}
