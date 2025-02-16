using Software.Menu.Models;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class CategoryClient : BaseClient
    {
        public CategoryClient() { }
        public CategoryClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }
        public async Task<List<Category>> GetProductCategories(string cnpj,int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"categories/product/{id}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Category> categories = JsonSerializer.Deserialize<List<Category>>(content, options);
            return categories;
        }
    }
}
