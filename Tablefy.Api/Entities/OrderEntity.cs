using System.ComponentModel.DataAnnotations.Schema;

namespace Tablefy.Api.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public string Note { get; set; }
        public CheckEntity Check { get; set; }
        public int CheckId { get; set; }
        public int Status { get; set; }
        public int CompanyId { get; set; }

        public ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
    }
}