namespace Tablefy.Order.Api.Order.Models
{
    public class OrderCreateResponseModel
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
