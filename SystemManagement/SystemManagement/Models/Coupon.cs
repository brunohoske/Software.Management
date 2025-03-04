namespace SystemManagement.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public Store Store { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public bool Active { get; set; }
    }
}
