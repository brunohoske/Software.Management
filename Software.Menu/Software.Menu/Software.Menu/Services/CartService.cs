using Microsoft.Extensions.Caching.Memory;
using Software.Menu.Models;
using Software.Menu.Models.ViewModels;

namespace Software.Menu.Services
{
    public class CartService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly string _cartKey = "UserCart_"; // Base key for each user

        public CartService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            // Cache entry expiration policy
            _cacheOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(15), // Clears after 15 minutes of inactivity
                Priority = CacheItemPriority.Normal, // Normal priority for automatic cleanup
                PostEvictionCallbacks = { new PostEvictionCallbackRegistration { EvictionCallback = OnCacheItemRemoved } }
            };
        }

        public List<ItemCart> GetCart(string token)
        {
            string cacheKey = _cartKey + token;
            return _memoryCache.Get<List<ItemCart>>(cacheKey) ?? new List<ItemCart>();
        }
        public static bool AreCombosEqual(ProductCartModel combo1, ProductCartModel combo2)
        {
            if (combo1 == null || combo2 == null)
                return false;
            if (combo1.Id != combo2.Id || combo1.ProductName != combo2.ProductName)
                return false;
            if (combo1.ComboProducts == null && combo2.ComboProducts == null)
                return true;
            if (combo1.ComboProducts == null || combo2.ComboProducts == null)
                return false;
            if (combo1.ComboProducts.Count != combo2.ComboProducts.Count)
                return false;
            for (int i = 0; i < combo1.ComboProducts.Count; i++)
            {
                if (combo1.ComboProducts[i].Id != combo2.ComboProducts[i].Id || combo1.ComboProducts[i].ProductName != combo2.ComboProducts[i].ProductName)
                    return false;
            }

            return true;
        }
        public void AddToCart(string token, ItemCart item)
        {
            string cacheKey = _cartKey + token;
            var cart = GetCart(token);

            if(item.Product.IsCombo)
            {
                var index = cart.FindIndex(p =>
                   p.Product.Id == item.Product.Id &&
                   p.Product.ProductName == item.Product.ProductName &&
                   p.Notes.SequenceEqual(item.Notes) &&
                   AreCombosEqual(p.Product, item.Product));

                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(item);
                }
            }
            else
            {
                var existingItem = cart.FirstOrDefault(p => p.Product.Id == item.Product.Id && !p.Product.IsCombo);
                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    cart.Add(item);
                }
            }


            // Store cart with expiration policy
            _memoryCache.Set(cacheKey, cart, _cacheOptions);
        }

        public void RemoveFromCart(string token, ItemCart item)
        {
            string cacheKey = _cartKey + token;
            var cart = GetCart(token);

            cart.Remove(item);

            if (cart.Any())
                _memoryCache.Set(cacheKey, cart, _cacheOptions);
            else
                _memoryCache.Remove(cacheKey); // Remove empty cart
        }

        public void ClearCart(string token)
        {
            string cacheKey = _cartKey + token;
            _memoryCache.Remove(cacheKey);
        }

        public void ClearAll()
        {
            if (_memoryCache is MemoryCache memoryCache)
            {
                memoryCache.Compact(1.0); 
            }

        }

        private void OnCacheItemRemoved(object key, object value, EvictionReason reason, object state)
        {
            Console.WriteLine($"Cart {key} was removed due to {reason}");
        }
    }

}
