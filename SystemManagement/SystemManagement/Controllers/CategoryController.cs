using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryDao _categoryDao;
        private readonly HeaderService _headerService;

        public CategoryController(CategoryDao categoryDao, HeaderService headerService)
        {
            _categoryDao = categoryDao;
            _headerService = headerService;
        }
        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            Store store = _headerService.GetCnpj();
            Category category = new Category() { Store = store };

            List<Category> categories = _categoryDao.GetCategories(store);
            return Ok(categories);
        }

        [HttpGet("Categories/{id}/Products")]
        public IActionResult GetCategories(int id)
        {
            Store store = _headerService.GetCnpj();
            List<Product> products = _categoryDao.GetProductCategories(store,id);
            return Ok(products);
        }

        [HttpGet("Product/{id}/Reccomended")]
        public IActionResult GetReccomendations(int id)
        {
            Store store = _headerService.GetCnpj();
            List<Product> products = _categoryDao.GetProductCategories(store, id);
            return Ok(products);
        }

    }
}
