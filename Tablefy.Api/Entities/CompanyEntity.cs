namespace Tablefy.Api.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        public CompaniesGroupEntity CompaniesGroup { get; set; }
        public int CompaniesGroupId { get; set; }

        public ICollection<CompanyProductEntity> CompanyProducts { get; set; } = new List<CompanyProductEntity>();
    }
}