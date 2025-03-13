namespace Tablefy.Api.Coupon
{
    public class CouponEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public bool Active { get; set; }
        public int CompanyId { get; set; }
    }
}