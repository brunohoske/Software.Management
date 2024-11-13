using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;
using MercadoPago.Client;
using Software.Menu.Models;
using System.Text.Json;

namespace Software.Menu.Client
{

    public class PaymentClient : BaseClient
    {
        public PaymentClient(string cnpj)
        {
            _httpClient.DefaultRequestHeaders.Add("cnpj", cnpj);
        }
        public async Task<Payment> Payment(PaymentUser payer, int value)
        {
            MercadoPagoConfig.AccessToken = "ENV_ACCESS_TOKEN";

            var requestOptions = new RequestOptions();
            requestOptions.CustomHeaders.Add("x-idempotency-key", "<SOME_UNIQUE_VALUE>");

            var request = new PaymentCreateRequest
            {
                TransactionAmount = value,
                Description = "Pagamento Comanda",
                PaymentMethodId = "pix",
                Payer = new PaymentPayerRequest
                {
                    Email = payer.Email,
                    FirstName = payer.Name,
                    LastName = payer.LastName,
                    Identification = new IdentificationRequest
                    {
                        Type = "CPF",
                        Number = payer.Identification,
                    },
                },
            };

            var client = new MercadoPago.Client.Payment.PaymentClient();
            Payment payment = await client.CreateAsync(request, requestOptions);
            return payment;
        }

        public async Task<int> GetPaymentValue()
        {
            HttpResponseMessage response = _httpClient.GetAsync("GetPaymetValue").Result;
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            int value = JsonSerializer.Deserialize<int>(content, options);



            return value;
        }

    }
}
