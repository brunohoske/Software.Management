
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tablefy.Api.Data;

namespace Tablefy.Api.Company.Services
{
    public class CompanyService
    {
        private readonly TablefyContext _context;
        private readonly IMapper _mapper;

        public CompanyService(TablefyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CompanyModel?> GetCompanyByCnpj(string cnpj)
        {
            var companyEntity = await _context.Companies.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
            if (companyEntity == null) return null;
            var model = _mapper.Map<CompanyModel>(companyEntity);
            return model;
        }
        public async Task<CompanyModel?> GetCompanyById(int id)
        {
            var companyEntity = await _context.Companies.FindAsync(id);
            if (companyEntity == null) return null;
            var model = _mapper.Map<CompanyModel>(companyEntity);
            return model;
        }
    }
}
