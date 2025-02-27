using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.Models;
using SystemManagement.Services;

namespace SystemManagement.Controllers
{
    public class IngredientController : BaseController
    {
        private readonly IngredientDao _ingredientDao;
        private readonly HeaderService _headerService;

        public IngredientController(IngredientDao ingredientDao, HeaderService headerService)
        {
            _ingredientDao = ingredientDao;
            _headerService = headerService;
        }

        [HttpGet("Ingredient")]
        public IActionResult GetIngredients()
        {
            string cnpj = _headerService.GetCnpj();
            List<Ingredient> ingredients = _ingredientDao.GetIngredients(cnpj);
            return Ok(ingredients);
        }

        [HttpGet("Ingredient/{id}")]
        public IActionResult GetIngredientFromId(int id)
        {
            string cnpj = _headerService.GetCnpj();
            Ingredient ingredient = _ingredientDao.GetIngredientFromId(id, cnpj);
            return Ok(ingredient);
        }

        [HttpGet("ProductIngredients/{idProduct}")]
        public IActionResult GetProductIngredients(int idProduct)
        {
            string cnpj = _headerService.GetCnpj();
            List<Ingredient> ingredients = _ingredientDao.GetProductIngredients(idProduct, cnpj);
            return Ok(ingredients);
        }

    }
}
