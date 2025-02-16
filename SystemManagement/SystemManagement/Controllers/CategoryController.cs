using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryDao _categoryDao;

        public CategoryController(CategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }
        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Store store = new Store() { Cnpj = cnpj };
            Category category = new Category() { Store = store };

            List<Category> categories = _categoryDao.GetCategories(store);
            return Ok(categories);
        }

        [HttpGet("Categories/{id}/Products")]
        public IActionResult GetCategories(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            List<Product> products = _categoryDao.GetProductCategories(cnpj,id);
            return Ok(products);
        }

        [HttpGet("Product/{id}/Reccomended")]
        public IActionResult GetReccomendations(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            List<Product> products = _categoryDao.GetProductCategories(cnpj, id);
            return Ok(products);
        }

    }
}
