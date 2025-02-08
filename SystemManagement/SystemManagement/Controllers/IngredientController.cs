using Microsoft.AspNetCore.Mvc;
using SystemManagement.Dao;
using SystemManagement.Models;

namespace SystemManagement.Controllers
{
    public class IngredientController : BaseController
    {
        [HttpGet("Ingredient")]
        public IActionResult GetIngredients()
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            List<Ingredient> ingredients = IngrdientDao.GetIngredients(cnpj);
            return Ok(ingredients);
        }

        [HttpGet("Ingredient/{id}")]
        public IActionResult GetIngredientFromId(int id)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            Ingredient ingredient = IngrdientDao.GetIngredientFromId(id, cnpj);
            return Ok(ingredient);
        }

        [HttpGet("ProductIngredients/{idProduct}")]
        public IActionResult GetProductIngredients(int idProduct)
        {
            string cnpj = Request.Headers.FirstOrDefault(x => x.Key == "cnpj").Value;
            List<Ingredient> ingredients = IngrdientDao.GetProductIngredients(idProduct, cnpj);
            return Ok(ingredients);
        }

    }
}
