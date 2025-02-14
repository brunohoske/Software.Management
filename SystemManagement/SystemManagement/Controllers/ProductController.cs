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
            List<Product> products = ProductDao.GetProducts(store);
            return Ok(products);
        }
        [HttpGet("Product/{id}")]
        public IActionResult GetProductFromID(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };

            Product product =  ProductDao.GetProductFromId(id,cnpj);
            return Ok(product);
        }
        [HttpGet("Product/{id}/Acompanhamentos")]
        public IActionResult GetAcompanhamentos(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            try
            {
                return Ok(ProductDao.GetAcompanhamentos(id, cnpj));
            }
            catch
            {
                return BadRequest();
            }
            
        }

    }
}
