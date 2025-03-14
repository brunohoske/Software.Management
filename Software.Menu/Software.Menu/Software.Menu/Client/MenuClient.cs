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

 

        
    }
}
