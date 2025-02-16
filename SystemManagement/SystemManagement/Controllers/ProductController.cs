using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.DAO;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ProductDao _productDao;
        private readonly HeaderService _headerService;

        public ProductController(ProductDao productDao, HeaderService headerService)
        {
            _productDao = productDao;
            _headerService = headerService;
        }

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            List<Product> products = _productDao.GetProducts(store);
            return Ok(products);
        }
        [HttpGet("Product/{id}")]
        public IActionResult GetProductFromID(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };

            Product product = _productDao.GetProductFromId(id,cnpj);
            return Ok(product);
        }
        [HttpGet("Product/{id}/Acompanhamentos")]
        public IActionResult GetAcompanhamentos(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            try
            {
                return Ok(_productDao.GetAcompanhamentos(id, cnpj));
            }
            catch
            {
                return BadRequest();
            }
            
        }

    }
}
