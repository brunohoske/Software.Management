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

        public async Task<bool> CheckExists(int tableId,int companyId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"/api/menu/tables/exists/{companyId}/{tableId}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var exist = JsonSerializer.Deserialize<TableExistsModel>(content, options);
            if (exist.Value)
            {
                return true;
            }
            return false;
        }
    }
}
