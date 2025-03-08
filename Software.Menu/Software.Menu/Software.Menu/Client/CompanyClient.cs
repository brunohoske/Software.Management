using Software.Menu.Models;
using System.Text.Json;

namespace Software.Menu.Client
{
    public class CompanyClient: BaseClient
    {
        public CompanyClient() { }
        public CompanyClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }

        public async Task<bool> CheckStoreExists(string cnpj)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Check/Store/{cnpj}").Result;
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<Company> GetCompanyFromCnpj(string cnpj)
        {
            if (CheckStoreExists(cnpj).Result)
            {
                HttpResponseMessage response = _httpClient.GetAsync($"Company/{cnpj}").Result;
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<Company>(content, options);
                }
            }
           
           
            return null;
            

        }
    }
}
