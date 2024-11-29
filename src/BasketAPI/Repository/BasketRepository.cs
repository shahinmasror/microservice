using BasketAPI.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketAPI.Repository
{
    public class BasketRepository : IBasketRepository
    {
        public readonly IDistributedCache _redisCash;
        public BasketRepository(IDistributedCache redisCash)
        {
         _redisCash = redisCash;
        }
        public async Task DeleteBasket(string userName)
        {
            await _redisCash.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCash.GetStringAsync(userName);
            if (basket == null) 
            {
                return null;

            }
            else
            {
                return JsonConvert.DeserializeObject<ShoppingCart>(basket);
            }

        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCash.SetStringAsync(basket.Name,JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.Name);
        }
    }
}
