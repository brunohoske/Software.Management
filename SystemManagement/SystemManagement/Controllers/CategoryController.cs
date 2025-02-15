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

    }
}
