namespace Tablefy.Api.Product.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int CompaniesGroupId { get; set; }
        public string Description { get; set; }
        public float Kcal { get; set; }
        public string Image { get; set; }
        public string Barcode { get; set; }
        public bool IsCombo { get; set; }
    }
}