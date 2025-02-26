using Software.Menu.Models;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class CheckClient :BaseClient
    {
        public CheckClient() { }
        public CheckClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }

        public async Task<bool> CloseCheck(Table table)
        {
            string jsonbody = JsonSerializer.Serialize(table);
            HttpContent content = new StringContent(jsonbody, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("CloseCheck", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckExists(int idTable)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"CheckExists/{idTable}").Result;
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var tableJson = JsonSerializer.Deserialize<Table>(content, options);
        }
    }
}
