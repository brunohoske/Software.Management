using System.Text.Json.Serialization;

namespace Tablefy.Order.Api.Order.Models
{
    public class OrderCreateModel
    {
        public int TableId { get; set; }
        public OrderStatusOptions Status { get; set; }
        public int CompanyId { get; set; }
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();

        [JsonIgnore]
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }

        [JsonIgnore]
        public decimal Total { get; set; }
    }
}
