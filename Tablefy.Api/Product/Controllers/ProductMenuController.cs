using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using Tablefy.Api.Product.Models;
using Tablefy.Api.Product.Services;

namespace Tablefy.Api.Product.Controllers
{
    [ApiController]
    [Route("api/erp/product")]
    public class ProductMenuController : ControllerBase
    {
        private readonly ProductMenuService _service;

        public ProductMenuController(ProductMenuService service)
        {
            _service = service;
        }

        [Route("catalog/{companyId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisplayCatalogModel>>> GetAll(int companyId)
        {
            var items = await _service.GetProductsCatalogAsync(companyId);
            return Ok(items);
        }

        [Route("details/{companyId}/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProductCompleteModel>> GetDetailsById(int companyId, int id)
        {
            var product = await _service.GetDetailsByIdAsync(companyId, id);
            return Ok(product);
        }

        [Route("extras/{companyId}/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProductExtrasModel>> GetExtrasById(int companyId, int id)
        {
            var product = await _service.GetExtrasByIdAsync(companyId,id);
            return Ok(product);
        }
    }
}