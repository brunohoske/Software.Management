using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tablefy.Api.Infra;
using Tablefy.Order.Api.Order.Models;
using Tablefy.Order.Api.Order.Services;

namespace Tablefy.Order.Api.Order.Controllers
{
    [ApiController]
    [Route("api/menu/orders")]
    public class OrdersMenuController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersMenuController(OrderService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(UnprocessableReasonModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(OrderCreateResponseModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderCreateResponseModel>> CreateOrder([FromBody] OrderCreateModel order) 
        {
            try
            {
                return Ok(await _service.CreateOrder(order));
            }
            catch (BusinessException ex)
            {
                return UnprocessableEntity( new UnprocessableReasonModel { Reason = ex.Message });
            }
            
        }

        [HttpPost("list/{companyId}/table/{tableId}")]
        public async Task<ActionResult<List<OrderDisplayModel>>> GetOrdersByTableList(int companyId, int tableId)
        {
            var orders = await _service.GetOrdersByTable(companyId, tableId);
            if (orders.Count == 0)
                return NotFound();
            return Ok(orders);
        }
    }
}
