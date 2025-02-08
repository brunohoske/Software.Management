using System.Text.Json;
using Software.Menu.Models;

namespace Software.Menu.Client
{
    public class IngredientClient : BaseClient
    {
        public IngredientClient() { }
        public IngredientClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }

        public async Task<List<Ingredient>> GetIngredients(string cnpj)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Ingredients").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Ingredient> ingredients = System.Text.Json.JsonSerializer.Deserialize<List<Ingredient>>(content, options);
            return ingredients;
        }

        public async Task<List<Ingredient>> GetProductIngredients(int idProduct, string cnpj)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"ProductIngredients/{idProduct}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Ingredient> ingredients = System.Text.Json.JsonSerializer.Deserialize<List<Ingredient>>(content, options);
            return ingredients;
        }


    }
}
