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

        [HttpPost("list/{companyId}")]
        public async Task<ActionResult<OrderDisplayModel>> GetOrderByIdList(int companyId, [FromBody] OrderIdsModel orderIds)
        {
            var orders = await _service.GetOrderByIds(companyId, orderIds.OrderIds);
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }
    }
}
