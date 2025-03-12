namespace Tablefy.Api.Models
{
    public class CouponModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public bool Active { get; set; }
        public int CompanyId { get; set; }
    }
}