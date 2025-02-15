using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.DAO;
using SystemManagement.DTOs;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderDao _orderDao;
        private readonly HeaderService _headerService;

        public OrderController(OrderDao orderDao, HeaderService headerService)
        {
            _orderDao = orderDao;
            _headerService = headerService;
        }
        [HttpGet("Orders")]
        public IActionResult GetOrders()
        {
            List<Order> orders = new List<Order>();
            string cnpj = _headerService.GetCnpj();
            orders = _orderDao.GetOrders(new Store() { Cnpj = cnpj });
            return Ok(orders);
        }

        [HttpPost("Orders")]
        public IActionResult SendOrder([FromBody] OrderDTO order)
        {
            _orderDao.CreateOrder(order);
            return Index();
        }

        [HttpGet("OrderNumber")]
        public IActionResult GetOrderNumber()
        {
            string cnpj = _headerService.GetCnpj();
            int number = _orderDao.GetOrderNumber(new Store() { Cnpj = cnpj });

            return Ok(number);
        }

        [HttpGet("GetOrdersInTable/{comanda}")]
        public IActionResult GetOrdersInTable(int comanda)
        {
            List<Order> orders = new List<Order>();
            string cnpj = _headerService.GetCnpj();
            Store store = new Store() { Cnpj = cnpj };
            orders = _orderDao.GetOrdersInTable(store,new Table { TableNumber = comanda, Store = store });
            return Ok(orders);
        }

        [HttpPost("CompleteOrder")]
        public IActionResult CompleteOrder([FromBody] Order order)
        {
            string cnpj = _headerService.GetCnpj();
            _orderDao.CompleteOrder(order);

            return Ok();
        }

        [HttpGet("Order/{idOrder}/Status")]
        public IActionResult GetStatusOrder(int idOrder)
        {
            string cnpj = _headerService.GetCnpj();
            return Ok();
        }
    }
}
