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


        public async Task<Company> GetCompanyFromCnpj(string cnpj)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Company/{cnpj}").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (response.IsSuccessStatusCode)
            {
                return System.Text.Json.JsonSerializer.Deserialize<Company>(content, options);
            }
            return new Company();

        }
    }
}
