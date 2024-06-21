using Software.ViewPanel.Models;
using System.Text.Json;

namespace Software.ViewPanel.Client
{
    public class SoftwareClient
    {
        HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7289") };


        public SoftwareClient()
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", "42591651000143");
        }
        public async Task<List<Order>> GetOrder()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Orders").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Order> o = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(content, options);



            return o;
        }

    }
}
