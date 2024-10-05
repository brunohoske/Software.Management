using System.Text.Json.Serialization;

namespace Software.Menu.Models
{
    public class Coupon
    {
        [JsonPropertyName("couponId")]
        public int CouponId { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("discount")]
        public double Discount { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
