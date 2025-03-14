using Tablefy.Api.Auth;

namespace Tablefy.Api.Company
{
    public class CompaniesGroupEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public ICollection<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();
    }
}
