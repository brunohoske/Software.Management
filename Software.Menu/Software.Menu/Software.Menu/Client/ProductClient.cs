using Microsoft.Extensions.Options;
using Software.Menu.Models;
using System.ComponentModel.Design;
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

        public async Task<List<DisplayCatalogModel>> GetCatalog(int companyId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"api/erp/products/catalog/{companyId}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions 
            {
                PropertyNameCaseInsensitive = true
            };
            List<DisplayCatalogModel> catalog = JsonSerializer.Deserialize<List<DisplayCatalogModel>>(content,options);
            return catalog;

        }

        public async Task<ProductCompleteModel> GetCompleteProduct(int idProduct)
        {

            HttpResponseMessage response = _httpClient.GetAsync($"api/erp/products/details/{idProduct}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ProductCompleteModel product = JsonSerializer.Deserialize<ProductCompleteModel>(content,options);
            return product;

        }

        public async Task<ProductExtrasModel> GetProductExtras(int idProduct)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"api/erp/products/extras/{idProduct}").Result;
            if(!response.IsSuccessStatusCode)
            {
               return new ProductExtrasModel();
            }
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ProductExtrasModel extras = JsonSerializer.Deserialize<ProductExtrasModel>(content,options);
            return extras;

        }


    }
}
