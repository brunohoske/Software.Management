using Software.Menu.Models.ViewModels;
using Software.Menu.Models;
using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;
using Software.Menu.Client;

namespace Software.Menu.Services
{
    public class MenuService
    {
        public readonly ProductClient _productClient;

        public MenuService(ProductClient productClient)
        {
            _productClient = productClient;
        }

        public async Task SetCartToken(string token, ISessionStorageService sessionStorageBlazored, int tableNumber, string cnpj)
        {
            try
            {
                await sessionStorageBlazored.SetItemAsStringAsync($"cart-{cnpj}-{tableNumber}", token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar o carrinho na sessão" + ex);
                throw;
            }

        }

        public async Task<string> GetCartToken(ISessionStorageService sessionStorageBlazored, int tableNumber, string cnpj)
        {
            try
            {
                var token = await sessionStorageBlazored.GetItemAsStringAsync($"cart-{cnpj}-{tableNumber}");
                if (token != null)
                {
                    return token;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler o TokenSession" + ex);
                return string.Empty;
                throw;
            }

        }

        public async Task SetProductSession(ISessionStorageService sessionStorageBlazored, ProductSimpleModel product)
        {
            try
            {
                var json = JsonSerializer.Serialize(product);
                await sessionStorageBlazored.SetItemAsStringAsync($"selectedProduct-{product.Id}", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar o carrinho na sessão" + ex);
                throw;
            }

        }

        public async Task<ProductCompleteModel> GetProductSession(ISessionStorageService sessionStorageBlazored,int productId)
        {
            try
            {
                var jsonProduct = await sessionStorageBlazored.GetItemAsStringAsync($"selectedProduct-{productId}");
                if(jsonProduct != null)
                {
                    var product = JsonSerializer.Deserialize<ProductCompleteModel>(jsonProduct);
                    product.Extras = await _productClient.GetProductExtras(product.Id);
                    return product;
                }
                return await _productClient.GetCompleteProduct(productId);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar o carrinho na sessão" + ex);
                throw;
            }
        }


    }
}
