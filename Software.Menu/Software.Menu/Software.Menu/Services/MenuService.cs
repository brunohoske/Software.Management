using Software.Menu.Models.ViewModels;
using Software.Menu.Models;
using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;

namespace Software.Menu.Services
{
    public class MenuService
    {
        public async Task SetSessionCart(List<ItemCart> itemCarts, ISessionStorageService sessionStorageBlazored, int tableNumber, string cnpj)
        {
            try
            {
                await sessionStorageBlazored.SetItemAsStringAsync($"cart-{cnpj}-{tableNumber}", JsonSerializer.Serialize(itemCarts));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar o carrinho na sessão" + ex);
                throw;
            }

        }

        public async Task<List<ItemCart>> GetSessionCart(ISessionStorageService sessionStorageBlazored,int tableNumber, string cnpj)
        {
            try
            {
                var cartJson = await sessionStorageBlazored.GetItemAsStringAsync($"cart-{cnpj}-{tableNumber}");
                if (cartJson != null)
                {
                    List<ItemCart> cart = JsonSerializer.Deserialize<List<ItemCart>>(cartJson);
                    byte[] bytes = Encoding.UTF8.GetBytes(cartJson);

                    double tamanhoMB = bytes.Length / (1024.0 * 1024.0);

                    Console.WriteLine($"Tamanho do JSON: {tamanhoMB:F6} MB");
                    return cart;

                    
                }
                else
                {
                    Console.WriteLine(cartJson);
                    return new List<ItemCart>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler o CarrinhoSession" + ex);
                return new List<ItemCart>();
                throw;
            }

        }
    }
}
