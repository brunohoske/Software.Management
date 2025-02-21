using Software.Menu.Models;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class ComboClient : BaseClient
    {
        public ComboClient() { }
        public ComboClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }
        public async Task<Combo> GetComboFromId(int idCombo)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Combos/{idCombo}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Combo combo = JsonSerializer.Deserialize<Combo>(content, options);
            return combo;
        }
    }
}
