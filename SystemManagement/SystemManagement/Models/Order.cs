using SystemManagement.DAO;
using SystemManagement.DTOs;

namespace SystemManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Store Store { get; set; }
        public Table Table { get; set; }

        public int Status { get; set; }

    }
}
