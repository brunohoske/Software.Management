using SystemManagement.Models;

namespace SystemManagement.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public List<ProductDTO> Products { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Store Store { get; set; }
        public Table Table { get; set; }
    }
}
