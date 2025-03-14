namespace Software.Menu.Models
{
    public class OrderDisplayModel
    {
        public int OrderNumber { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; } = 1;
        
        public List<OrderItemDisplayModel> Items { get; set; } = new List<OrderItemDisplayModel>();
    }
}
