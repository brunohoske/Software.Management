namespace SystemManagement.Services
{
    public class HeaderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HeaderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetCnpj()
        {
            return _httpContextAccessor.HttpContext?.Request.Headers["cnpj"].FirstOrDefault();
        }
    }
}
