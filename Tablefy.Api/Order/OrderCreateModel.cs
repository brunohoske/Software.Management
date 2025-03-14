using System.ComponentModel.DataAnnotations.Schema;
using Tablefy.Api.Check;
using Tablefy.Api.Order.Entities.Relations;

namespace Tablefy.Api.Order
{
    public class OrderCreateModel
    {
        public int Id { get; set; }
        
        public bool Active { get; set; }
        public string Note { get; set; }
        public int CheckId { get; set; }
        public OrderStatusOptions Status { get; set; }
        public int CompanyId { get; set; }
        public ICollection<OrderItemModel> OrderProducts { get; set; } = new List<OrderItemModel>();
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
