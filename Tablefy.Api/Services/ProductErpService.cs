using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tablefy.Api.Data;
using Tablefy.Api.Entities;
using Tablefy.Api.Models;

namespace Tablefy.Api.Services
{
    public class ProductErpService
    {
        private readonly TablefyContext _context;
        private readonly IMapper _mapper;

        public ProductErpService(TablefyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var entities = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(entities);
        }

        public async Task<IEnumerable<ProductModel>> GetAllFromCompanyGroupAsync(int companyGroupId)
        {
            var products = await _context.Products
                .Where(p => p.CompaniesGroupId == companyGroupId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }
        public async Task<IEnumerable<ProductModel>> GetProductsCatalogAsync(int companyId)
        {
            var products = await _context.Products
                .Include(p => p.CompanyProducts)
                .Where(p => p.CompanyProducts.Any(cp => cp.CompanyId == companyId))
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }
        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            return entity != null ? _mapper.Map<ProductModel>(entity) : null;
        }

        public async Task CreateAsync(ProductModel model)
        {
            var entity = _mapper.Map<ProductEntity>(model);
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductModel model)
        {
            var entity = _mapper.Map<ProductEntity>(model);
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}