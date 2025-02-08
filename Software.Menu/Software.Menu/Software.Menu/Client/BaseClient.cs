namespace Software.Menu.Client
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _httpClient = new HttpClient {BaseAddress = new Uri("https://localhost:7289") };
        public string Cnpj { get; set; }
    }
}
