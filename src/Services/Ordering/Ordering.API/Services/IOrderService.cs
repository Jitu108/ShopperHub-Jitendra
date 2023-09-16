using Ordering.API.Dtos;

namespace Ordering.API.Services
{
    public interface IOrderService
    {
        Task<bool> AddOrder(OrderCreate order);
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId);
        Task<OrderDto> GetOrderById(int id);
    }
}
