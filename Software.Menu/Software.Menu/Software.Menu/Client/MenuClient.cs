using Software.Menu.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class MenuClient : BaseClient
    {
        public MenuClient() 
        {
        }
        public MenuClient(string cnpj) 
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }

        

        public async Task<List<Order>> GetOrders(int comanda)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"GetOrdersInTable/{comanda}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Order> o = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(content, options);



            return o;
        }

        public async Task<Coupon> SearchCoupon(string code)
        {
            
            _httpClient.DefaultRequestHeaders.Add("code",code);
            HttpResponseMessage response = _httpClient.GetAsync("SearchCoupon").Result;
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Coupon coupon = JsonSerializer.Deserialize<Coupon>(content);
                _httpClient.DefaultRequestHeaders.Remove("code");

                return coupon;
            }
            _httpClient.DefaultRequestHeaders.Remove("code");

            return null ;
           

        }

        public async Task<List<Category>> GetCategories()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Categories").Result;
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
