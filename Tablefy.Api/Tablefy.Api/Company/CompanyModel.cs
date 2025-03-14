namespace Tablefy.Api.Company
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; }
        public string Banner { get; set; }
        public CompaniesGroupEntity CompaniesGroup { get; set; }
        public int CompaniesGroupId { get; set; }
    }
}
