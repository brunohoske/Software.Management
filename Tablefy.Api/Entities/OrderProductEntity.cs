﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace Tablefy.Api.Entities
{
    public class OrderProductEntity
    {
        public int CompanyId { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime AddedAt { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}