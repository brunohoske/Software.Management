using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Tablefy.Api.Data;
using Tablefy.Api.Product.Entities;
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
                .ThenInclude(p => p.CompanyProducts.Where(cp => cp.CompanyId == companyId && cp.Active))
                .Where(p => p.ProductCategories.Any(x => x.Product.CompanyProducts.Any(cp => cp.CompanyId == companyId) && x.Category.DisplayMainPage))
                .ToListAsync();
            return _mapper.Map<IEnumerable<DisplayCatalogModel>>(products);
        }
        public async Task<ProductCompleteModel> GetDetailsByIdAsync(int companyId, int id)
        {
            var entity = await _context.Products
                    .Include(p => p.CompanyProducts.Where(cp => cp.CompanyId == companyId))
                    .IncludeExtras(companyId)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            return entity != null ? _mapper.Map<ProductCompleteModel>(entity) : null;
        }

        public async Task<ProductExtrasModel> GetExtrasByIdAsync(int companyId, int id)
        {
            var entity = await _context.Products
                    .IncludeExtras(companyId)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            return entity != null ? _mapper.Map<ProductExtrasModel>(entity) : null;
        }
        
    }
    internal static class ProductMenuServiceQueryExtension
    {
        public static IQueryable<ProductEntity> IncludeExtras(this IQueryable<ProductEntity> products, int companyId)
        {
           return products
                .Include(p => p.ProductsSides)
                        .ThenInclude(ps => ps.Side)
                        .ThenInclude(pscp => pscp.CompanyProducts.Where(cp => cp.CompanyId == companyId))
                    .Include(p => p.ProductRecommendations)
                        .ThenInclude(pr => pr.Category)
                        .ThenInclude(prpc => prpc.ProductCategories)
                        .ThenInclude(prpcp => prpcp.Product)
                        .ThenInclude(prpcpcp => prpcpcp.CompanyProducts.Where(cp => cp.CompanyId == companyId))
                    .Include(p => p.ProductIngredients)
                        .ThenInclude(pi => pi.Ingredient)
                    .Include(p => p.ComboProducts.Where(cp => cp.Combo.IsCombo))
                        .ThenInclude(combo => combo.Product)
                        .ThenInclude(combocp => combocp.CompanyProducts.Where(cp => cp.CompanyId == companyId))
                    .Include(p => p.ComboSelectionGroups)
                        .ThenInclude(sgp => sgp.SelectionGroup)
                        .ThenInclude(sg => sg.SelectionGroupProducts)
                        .ThenInclude(sgp => sgp.Product)
                        .ThenInclude(sgpcp => sgpcp.CompanyProducts.Where(cp => cp.CompanyId == companyId));
        }
    }
}