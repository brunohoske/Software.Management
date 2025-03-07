using Microsoft.Extensions.Caching.Memory;
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

        public void AddToCart(string token, ItemCart item)
        {
            string cacheKey = _cartKey + token;
            var cart = GetCart(token);

            var existingItem = cart.FirstOrDefault(p => p.Product.Id == item.Product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Add(item);
            }

            // Store cart with expiration policy
            _memoryCache.Set(cacheKey, cart, _cacheOptions);
        }

        public void RemoveFromCart(string token, int productId)
        {
            string cacheKey = _cartKey + token;
            var cart = GetCart(token);

            cart.RemoveAll(p => p.Product.Id == productId);

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

        private void OnCacheItemRemoved(object key, object value, EvictionReason reason, object state)
        {
            Console.WriteLine($"Cart {key} was removed due to {reason}");
        }
    }

}
