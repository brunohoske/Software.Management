using System.ComponentModel.DataAnnotations.Schema;
using Tablefy.Api.Check;
using Tablefy.Api.Order.Entities.Relations;

namespace Tablefy.Api.Order.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string Note { get; set; }
        public CheckEntity Check { get; set; }
        public int CheckId { get; set; }
        public OrderStatusOptions Status { get; set; }
        public int CompanyId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
    }
}