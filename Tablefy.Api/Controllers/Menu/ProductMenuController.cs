using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using Tablefy.Api.Entities;
using Tablefy.Api.Models;
using Tablefy.Api.Services;

namespace Tablefy.Api.Controllers
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

        [Route("details/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProductCompleteModel>> GetDetailsById(int id)
        {
            var product = await _service.GetDetailsByIdAsync(id);
            return Ok(product);
        }

        [Route("extras/{id}")]
        [HttpGet]
        public async Task<ActionResult<ProductExtrasModel>> GetExtrasById(int id)
        {
            var product = await _service.GetExtrasByIdAsync(id);
            return Ok(product);
        }
    }
}