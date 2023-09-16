using Basket.API.Data.Entities;

namespace Basket.API.Data
{
    public interface IShoppingCartRepo
    {
        public Task<ShoppingCart> GetBasket(int userId);
        public Task<ShoppingCart> UpdateBasket(int userId, ShoppingCartItem item);

        public Task<bool> DeleteBasket(int userId);
    }
}
