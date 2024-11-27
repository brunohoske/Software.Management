

using System.Text.Json.Serialization;

namespace Software.ViewPanel.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double Value { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public Store Store { get; set; }
        public Table Table { get; set; }

    }
}
