using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Services
{
    public class HeaderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StoreDao _storeDao;

        public HeaderService(IHttpContextAccessor httpContextAccessor,StoreDao storeDao)
        {
            _httpContextAccessor = httpContextAccessor;
            _storeDao = storeDao;
        }

        public Store? GetCnpj()
        {
            string cnpj = _httpContextAccessor.HttpContext?.Request.Headers["cnpj"].FirstOrDefault();
            return _storeDao.GetCompanyFromCnpj(cnpj);
        }
    }
}
