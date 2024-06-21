using Microsoft.AspNetCore.Mvc;
using System.Data;
using SystemManagement.Dao;
using SystemManagement.DAO;
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
            OrderDao dao = new OrderDao();
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            orders = dao.GetOrders(store);
            return Ok(orders);
        }

        [HttpPost("Orders")]
        public IActionResult SendOrder([FromBody]Order order)
        {
            OrderDao dao = new OrderDao();
            Console.WriteLine(order);
            dao.CreateOrder(order);
           
            return Index();
        }

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj};
            ProductDao dao = new ProductDao();

            List<Product> products = dao.GetProducts(store);
            return Ok(products);
        }

        [HttpGet("OrderNumber")]
        public IActionResult GetOrderNumber()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            OrderDao dao = new OrderDao();

            int number = dao.GetOrderNumber(store);
            return Ok(number);
        }

        [HttpGet("GetOrdersInTable")]
        public IActionResult GetOrdersInTable()
        {
            List<Order> orders = new List<Order>();
            OrderDao dao = new OrderDao();
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            Table t = new Table { TableNumber = 1, Store = store };
            orders = dao.GetOrdersInTable(store,t);
            return Ok(orders);
        }
    }
}
