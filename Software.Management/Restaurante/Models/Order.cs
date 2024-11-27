
namespace Restaurante.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Produto> Products { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Store Store { get; set; }
    }
}
