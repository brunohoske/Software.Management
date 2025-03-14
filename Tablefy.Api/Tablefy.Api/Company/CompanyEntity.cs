using Tablefy.Api.Product.Entities.Relations;

namespace Tablefy.Api.Company
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

        public ICollection<ProductCompanyEntity> CompanyProducts { get; set; } = new List<ProductCompanyEntity>();
    }
}