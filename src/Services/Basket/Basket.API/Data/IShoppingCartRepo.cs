using Basket.API.Data.Entities;

namespace Basket.API.Data
{
    public interface IShoppingCartRepo
    {
        public Task<ShoppingCart> GetBasket(string userId);
        public Task<ShoppingCart> UpdateBasket(string userId, ShoppingCartItem item);

        public Task DeleteBasket(string userName);
    }
}
