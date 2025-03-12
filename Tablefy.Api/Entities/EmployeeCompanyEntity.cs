namespace Tablefy.Api.Entities
{
    public class EmployeeCompanyEntity
    {
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
    }
}