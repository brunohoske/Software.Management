namespace Tablefy.Api.Entities
{
    public class ProductSidesEntity
    {
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int SideId { get; set; }
        public ProductEntity Side { get; set; }
    }
}
