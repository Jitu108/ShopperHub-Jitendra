using UserBff.Dtos;

namespace UserBff.InterServiceCommunication.SyncDataClient
{
    public interface IBasketClient
    {
        public Task<ShoppingCartDto> GetBasket(int userId);
        public Task<ShoppingCartDto> UpdateBasket(int userId, ShoppingCartItemDto item);

        public Task<bool> DeleteBasket(int userId);
    }
}
