namespace Tablefy.Order.Api.Order.Models
{
    public class OrderDisplayModel
    {
        public int OrderNumber { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public List<OrderItemDisplayModel> Items { get; set; } = new List<OrderItemDisplayModel>();
    }
}
