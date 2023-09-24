using Ordering.API.Dtos;
using Ordering.API.Enums;

namespace Ordering.API.Services
{
    public interface IOrderService
    {
        Task<bool> AddOrder(OrderCreate order);
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId);
        Task<OrderDto> GetOrderById(int id);

        Task<OrderStatusInfo> CancelOrder(CancelledOrderDto orderDto);
        Task<OrderStatusInfo> RefundOrder(int orderId);

        Task<RefundedOrderDto> GetRefundedOrder(int orderId);
    }
}
