using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using Tablefy.Api.Entities;
using Tablefy.Api.Models;
using Tablefy.Api.Services;

namespace Tablefy.Api.Controllers.Erp
{
    [ApiController]
    [Route("api/erp/product")]
    public class ProductErpController : ControllerBase
    {
        private readonly ProductErpService _service;
        private readonly IMapper _mapper;

        public ProductErpController(ProductErpService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var models = _mapper.Map<IEnumerable<ProductModel>>(entities);
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();
            var model = _mapper.Map<ProductModel>(entity);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductModel model)
        {
            if (model == null) return BadRequest();
            await _service.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.CompaniesGroupId }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductModel model)
        {
            if (model == null || id != model.CompaniesGroupId) return BadRequest();
            await _service.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}