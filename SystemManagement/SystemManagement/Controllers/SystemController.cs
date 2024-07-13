using Microsoft.AspNetCore.Mvc;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class SystemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            Product product = new Product() { Store = store };

            List<Product> products = product.GetProducts();
            return Ok(products);
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
    }
}
