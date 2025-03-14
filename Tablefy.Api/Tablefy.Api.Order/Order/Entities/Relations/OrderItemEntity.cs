using System.ComponentModel.DataAnnotations.Schema;

namespace Tablefy.Order.Api.Order.Entities.Relations
{
    public class OrderItemEntity
    {
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string TempImage { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public bool IsCombo { get; set; }
        public bool FromCombo { get; set; }
        /// Deve ser um valor representativo para produtos de combo para saber em qual combo foi comprado o item (ex: 1, 2,3)
        public int ComboReference { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime AddedAt { get; set; }
    }
}