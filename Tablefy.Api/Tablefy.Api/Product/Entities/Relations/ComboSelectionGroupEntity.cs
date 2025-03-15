namespace Tablefy.Api.Product.Entities.Relations
{
    public class ComboSelectionGroupEntity
    {
        public int ComboId { get; set; }
        public ProductEntity Combo { get; set; }

        public int SelectionGroupId { get; set; }
        public SelectionGroupEntity SelectionGroup { get; set; }
    }
}