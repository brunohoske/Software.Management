using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tablefy.Api.Data;
using Tablefy.Api.Product.Models;

namespace Tablefy.Api.Product.Services
{
    public class ProductMenuService
    {
        private readonly TablefyContext _context;
        private readonly IMapper _mapper;

        public ProductMenuService(TablefyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DisplayCatalogModel>> GetProductsCatalogAsync(int companyId)
        {
            var products = await _context.Categories
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.CompanyProducts)
                .Where(p => p.ProductCategories.Any(x => x.Product.CompanyProducts.Any(cp => cp.CompanyId == companyId) && x.Category.DisplayMainPage))
                .ToListAsync();
            return _mapper.Map<IEnumerable<DisplayCatalogModel>>(products);
        }
        public async Task<ProductCompleteModel> GetDetailsByIdAsync(int id)
        {
            var entity = await _context.Products
                
                    .Include(p => p.CompanyProducts)
                    .Include(p => p.ProductsSides)
                        .ThenInclude(p => p.Side)
                        .ThenInclude(p => p.CompanyProducts)
                    .Include(p => p.ProductRecommendations)
                        .ThenInclude(p => p.Category)
                        .ThenInclude(p => p.ProductCategories)
                        .ThenInclude(p => p.Product)
                        .ThenInclude(p => p.CompanyProducts)
                    .Include(p => p.ProductIngredients)
                        .ThenInclude(p => p.Ingredient)
                    .Include(p => p.SelectionGroupProducts)
                        .ThenInclude(p => p.SelectionGroup)
                        .ThenInclude(p => p.SelectionGroupProducts)
                        .ThenInclude(p => p.Product)
                        .ThenInclude(p => p.CompanyProducts)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            return entity != null ? _mapper.Map<ProductCompleteModel>(entity) : null;
        }

        public async Task<ProductExtrasModel> GetExtrasByIdAsync(int id)
        {
            var entity = await _context.Products
                    .Include(p => p.ProductsSides)
                        .ThenInclude(p => p.Side)
                        .ThenInclude(p => p.CompanyProducts)
                    .Include(p => p.ProductRecommendations)
                        .ThenInclude(p => p.Category)
                        .ThenInclude(p => p.ProductCategories)
                        .ThenInclude(p => p.Product)
                        .ThenInclude(p => p.CompanyProducts)
                    .Include(p => p.ProductIngredients)
                        .ThenInclude(p => p.Ingredient)
                    .Include(p => p.SelectionGroupProducts)
                        .ThenInclude(p => p.SelectionGroup)
                        .ThenInclude(p => p.SelectionGroupProducts)
                        .ThenInclude(p => p.Product)
                        .ThenInclude(p => p.CompanyProducts)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            return entity != null ? _mapper.Map<ProductExtrasModel>(entity) : null;
        }
    }
}