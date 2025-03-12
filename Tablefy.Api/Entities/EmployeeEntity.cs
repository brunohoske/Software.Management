namespace Tablefy.Api.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int CompaniesGroupId { get; set; }
        public CompaniesGroupEntity CompaniesGroup { get; set; }

        public ICollection<EmployeeCompanyEntity> EmployeeCompanies { get; set; } = new List<EmployeeCompanyEntity>();
    }
}
