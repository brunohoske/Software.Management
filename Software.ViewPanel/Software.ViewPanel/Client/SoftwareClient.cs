using Software.ViewPanel.Models;
using System.Text;
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

            List<Order> o = JsonSerializer.Deserialize<List<Order>>(content, options);



            return o.Where(x=> x.Status != 3).ToList();
        }

        
        public async Task CompleteOrder(Order order)
        {

            string json = JsonSerializer.Serialize(order);
            HttpContent content = new StringContent(json,UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("CompleteOrder", content).Result;
        }

    }
}
