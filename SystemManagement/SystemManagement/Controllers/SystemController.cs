using Microsoft.AspNetCore.Mvc;
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
        public IActionResult SendOrder(Order order)
        {
            OrderDao dao = new OrderDao();
            dao.CreateOrder(order);
            return Index();
        }
    }
}
