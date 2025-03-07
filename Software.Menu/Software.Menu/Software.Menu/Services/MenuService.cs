using Software.Menu.Models.ViewModels;
using Software.Menu.Models;
using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;

namespace Software.Menu.Services
{
    public class MenuService
    {

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


    }
}
