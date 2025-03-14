using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;

namespace Software.Menu.Models
{
    public class ProductSimpleModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("kcal")]
        public float Kcal { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("isCombo")]
        public bool IsCombo { get; set; }
        [JsonProperty("companyId")]
        public int? CompanyId { get; set; }
        [JsonProperty("productId")]
        public int? ProductId { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("active")]
        public bool? Active { get; set; }
        [JsonProperty("saleProduct")]
        public bool? SaleProduct { get; set; }
        [JsonProperty("percentageDiscount")]
        public decimal? PercentageDiscount { get; set; }
        [JsonProperty("valueDiscount")]
        public decimal? ValueDiscount { get; set; }

        public decimal GetPrice()
        {
            if (ValueDiscount != 0)
            {
                return (decimal)(Price - ValueDiscount);
            }
            else if (PercentageDiscount != 0)
            {
                return (decimal)(Price - ((Price * PercentageDiscount) / 100));
            }
            return (decimal)(Price);

        }
    }
}
