namespace Tablefy.Api.Product.Models
{
    public class SelectionGroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string ViewName { get; set; }
        public string GroupDescription { get; set; }

        public ICollection<SelectionGroupProductModel> SelectionGroupProducts { get; set; } = new List<SelectionGroupProductModel>();
    }
}