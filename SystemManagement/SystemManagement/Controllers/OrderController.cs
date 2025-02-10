using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.DAO;
using SystemManagement.DTOs;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class OrderController : BaseController
    {
        [HttpGet("Orders")]
        public IActionResult GetOrders()
        {
            List<Order> orders = new List<Order>();
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            orders = OrderDao.GetOrders(new Store() { Cnpj = cnpj });
            return Ok(orders);
        }

        [HttpPost("Orders")]
        public IActionResult SendOrder([FromBody] OrderDTO order)
        {
            OrderDao.CreateOrder(order);
            return Index();
        }

        [HttpGet("OrderNumber")]
        public IActionResult GetOrderNumber()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            int number = OrderDao.GetOrderNumber(new Store() { Cnpj = cnpj });

            return Ok(number);
        }

        [HttpGet("GetOrdersInTable/{comanda}")]
        public IActionResult GetOrdersInTable(int comanda)
        {
            List<Order> orders = new List<Order>();
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            orders = OrderDao.GetOrdersInTable(store,new Table { TableNumber = comanda, Store = store });
            return Ok(orders);
        }

        [HttpPost("CompleteOrder")]
        public IActionResult CompleteOrder([FromBody] Order order)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            OrderDao.CompleteOrder(order);

            return Ok();
        }

        [HttpGet("Order/{idOrder}/Status")]
        public IActionResult GetStatusOrder(int idOrder)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            

            return Ok();
        }
    }
}
