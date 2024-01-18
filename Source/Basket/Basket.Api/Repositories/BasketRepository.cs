using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redis;

        public BasketRepository(IDistributedCache redis)
        {
            _redis = redis ?? throw new ArgumentException(nameof(redis));
        }

        public async Task DeleteBasketAsync(string userName)
        {
            await _redis.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName)
        {
            var baskets = await _redis.GetStringAsync(userName);
            if (String.IsNullOrEmpty(baskets))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(baskets);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart shoppingCart)
        {
            await _redis.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
            return await GetBasketAsync(shoppingCart.UserName);
        }
    }
}
