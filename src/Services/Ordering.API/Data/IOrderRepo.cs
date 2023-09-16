using Ordering.API.Data.Entities;

namespace Ordering.API.Data
{
    public interface IOrderRepo
    {
        Task<bool> AddOrder(Order order);
        Task<IEnumerable<Order>> GetOrderByUserId(int userId);
        Task<Order> GetOrderById(int id);
    }
}
