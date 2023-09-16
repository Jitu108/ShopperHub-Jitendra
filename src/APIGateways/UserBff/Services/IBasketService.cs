using UserBff.Dtos;

namespace UserBff.Services
{
    public interface IBasketService
    {
        public Task<ShoppingCartDto> GetBasket(int userId);
        public Task<ShoppingCartDto> UpdateBasket(int userId, ShoppingCartItemDto item);

        public Task<bool> DeleteBasket(int userId);
    }
}
