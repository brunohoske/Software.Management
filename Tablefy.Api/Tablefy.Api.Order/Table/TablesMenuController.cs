using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tablefy.Order.Api.Table
{
    [Route("api/menu/tables")]
    [ApiController]
    public class TablesMenuController : ControllerBase
    {
        private readonly TableService _service;

        public TablesMenuController(TableService service)
        {
            _service = service;
        }
        [HttpGet("exists/{companyId}/{tableId}")]
        public async Task<ActionResult<TableExistsModel>> GetCompanyById(int companyId, int tableId)
        {
            var existsModel = await _service.GetTableExists(companyId, tableId);
            return Ok(existsModel);
        }
    }
}
