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
            Store store = _headerService.GetCnpj();
            List<Product> products = _productDao.GetProducts(store);
            return Ok(products);
        }
        [HttpGet("Product/{id}")]
        public IActionResult GetProductFromID(int id)
        {
            Store store = _headerService.GetCnpj();

            Product product = _productDao.GetProductFromId(id,store);
            return Ok(product);
        }
        [HttpGet("Product/{id}/Acompanhamentos")]
        public IActionResult GetAcompanhamentos(int id)
        {
            Store store = _headerService.GetCnpj();
            try
            {
                return Ok(_productDao.GetAcompanhamentos(id, store));
            }
            catch
            {
                return BadRequest();
            }
            
        }

    }
}
