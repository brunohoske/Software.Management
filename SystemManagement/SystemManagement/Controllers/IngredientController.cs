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
            Store store = _headerService.GetCnpj();
            List<Ingredient> ingredients = _ingredientDao.GetIngredients(store);
            return Ok(ingredients);
        }

        [HttpGet("Ingredient/{id}")]
        public IActionResult GetIngredientFromId(int id)
        {
            Store store = _headerService.GetCnpj();
            Ingredient ingredient = _ingredientDao.GetIngredientFromId(id, store);
            return Ok(ingredient);
        }

        [HttpGet("ProductIngredients/{idProduct}")]
        public IActionResult GetProductIngredients(int idProduct)
        {
            Store store = _headerService.GetCnpj();
            List<Ingredient> ingredients = _ingredientDao.GetProductIngredients(idProduct, store);
            return Ok(ingredients);
        }

    }
}
