using Microsoft.AspNetCore.Mvc;
using System.Data;
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



            return Index();
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
        public IActionResult GetOrder()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj};
            OrderDao dao = new OrderDao();

            List<Product> products = dao.GetProduct(store);
            return Ok(products);
        }
    }
}
