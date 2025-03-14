using System.ComponentModel.DataAnnotations.Schema;
using Tablefy.Order.Api.Table;
using Tablefy.Order.Api.Order.Entities.Relations;

namespace Tablefy.Order.Api.Order.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public TableEntity Table { get; set; }
        public int TableId { get; set; }
        public OrderStatusOptions Status { get; set; }
        public int CompanyId { get; set; }
        public int OrderNumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}