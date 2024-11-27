using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class ProductController : BaseController
    {

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            Product product = new Product() { Store = store };

            List<Product> products = product.GetProducts();
            return Ok(products);
        }

    }
}
