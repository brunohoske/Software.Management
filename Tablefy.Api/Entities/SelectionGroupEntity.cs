namespace Tablefy.Api.Entities
{
    public class SelectionGroupEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string ViewName { get; set; }
        public string GroupDescription { get; set; }
        public int CompanyId { get; set; }

        public ICollection<SelectionGroupProductEntity> SelectionGroupProducts { get; set; } = new List<SelectionGroupProductEntity>();
    }
}