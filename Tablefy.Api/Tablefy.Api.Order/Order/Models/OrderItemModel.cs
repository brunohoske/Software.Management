using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tablefy.Order.Api.Order.Models
{
    public class OrderItemModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string TempImage { get; set; }
        
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        [JsonIgnore]
        public decimal Total { get; set; }
        public bool IsCombo { get; set; }
        public bool FromCombo { get; set; }
        public int ComboReference { get; set; }
    }
}
