using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
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

            Order order = new Order() { Store = new Store() { Cnpj = cnpj } };
            orders = order.GetOrders();
            return Ok(orders);
        }

        [HttpPost("Orders")]
        public IActionResult SendOrder([FromBody] Order order)
        {
            order.CreateOrder();
            return Index();
        }

        [HttpGet("OrderNumber")]
        public IActionResult GetOrderNumber()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Order order = new Order() { Store = new Store() { Cnpj = cnpj } };
            int number = order.GetOrderNumber();

            return Ok(number);
        }

        [HttpGet("GetOrdersInTable")]
        public IActionResult GetOrdersInTable()
        {
            List<Order> orders = new List<Order>();
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            Table table = new Table { TableNumber = 1, Store = store };
            Order order = new Order() { Store = store, Table = table };
            orders = order.GetOrdersInTable();
            return Ok(orders);
        }

        [HttpPost("CompleteOrder")]
        public IActionResult CompleteOrder([FromBody] Order order)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            order.CompleteOrder();

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
