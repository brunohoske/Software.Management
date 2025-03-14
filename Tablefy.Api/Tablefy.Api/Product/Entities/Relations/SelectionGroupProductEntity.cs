namespace Tablefy.Api.Product.Entities.Relations
{
    public class SelectionGroupProductEntity
    {
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int SelectionGroupId { get; set; }
        public SelectionGroupEntity SelectionGroup { get; set; }
        public decimal Price { get; set; }
    }

}
