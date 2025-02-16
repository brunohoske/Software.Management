using Software.Menu.Models;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class ProductClient : BaseClient
    {
        public ProductClient() { }
        public ProductClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }
        public async Task<List<Product>> GetProducts()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Products").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(content, options);



            return products;
        }

        public async Task<Product> GetProductFromId(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Product/{id}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Product product = JsonSerializer.Deserialize<Product>(content, options);
            return product;
        }

        public async Task<List<Product>> GetAcompanhamentos(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Product/{id}/Acompanhamentos").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Product> acompanhamentos = JsonSerializer.Deserialize<List<Product>>(content, options);
            return acompanhamentos;

        }

    }
}
