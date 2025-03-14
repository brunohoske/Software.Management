using System.ComponentModel.DataAnnotations.Schema;

namespace Tablefy.Api.Order
{
    public class OrderItemModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string TempImage { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public bool IsCombo { get; set; }
        public bool FromCombo { get; set; }
        public int ComboReference { get; set; }
    }
}
