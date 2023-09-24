using AutoMapper;
using Ordering.API.Data;
using Ordering.API.Data.Entities;
using Ordering.API.Dtos;
using Ordering.API.Enums;

namespace Ordering.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo repo;
        private readonly IMapper mapper;

        public OrderService(IOrderRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<bool> AddOrder(OrderCreate order)
        {
            var orderModel = mapper.Map<Order>(order);
            
            var billingAddress = mapper.Map<Address>(order.BillingAddress);
            billingAddress.AddressType = AddressType.Billing;

            var deliveryAddress = mapper.Map<Address>(order.DeliveryAddress);
            deliveryAddress.AddressType = AddressType.Delivery;

            orderModel.Addresses = new List<Address>();
            orderModel.Addresses.Add(billingAddress);
            orderModel.Addresses.Add(deliveryAddress);

            var status = await repo.AddOrder(orderModel);
            return status;
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await repo.GetOrderById(id);
            var billingAddress = order.Addresses.Where(x => x.AddressType == AddressType.Billing).FirstOrDefault();
            var deliveryAddress = order.Addresses.Where(x => x.AddressType == AddressType.Delivery).FirstOrDefault();
            var orderDto = mapper.Map<OrderDto>(order);
            if (billingAddress != null) orderDto.BillingAddress = mapper.Map<AddressDto>(billingAddress);
            if (deliveryAddress != null) orderDto.DeliveryAddress = mapper.Map<AddressDto>(deliveryAddress);

            return orderDto;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId)
        {
            List<OrderDto> orderDtos = new List<OrderDto>();

            var orders = await repo.GetOrderByUserId(userId);
            foreach (var order in orders)
            {
                var billingAddress = order.Addresses.Where(x => x.AddressType == AddressType.Billing).FirstOrDefault();
                var deliveryAddress = order.Addresses.Where(x => x.AddressType == AddressType.Delivery).FirstOrDefault();
                var orderDto = mapper.Map<OrderDto>(order);
                if (billingAddress != null) orderDto.BillingAddress = mapper.Map<AddressDto>(billingAddress);
                if (deliveryAddress != null) orderDto.DeliveryAddress = mapper.Map<AddressDto>(deliveryAddress);
                orderDtos.Add(orderDto);
            }
            return orderDtos;
        }

        public async Task<OrderStatusInfo> CancelOrder(CancelledOrderDto orderDto)
        {
            var order = await repo.GetOrderById(orderDto.OrderId);

            if (order.OrderStatus == OrderStatus.Delivered)
            {
                return OrderStatusInfo.OrderCouldNotBeCancelledBecauseItIsDelivered;
            }

            if (order.OrderStatus == OrderStatus.Cancelled)
            {
                return OrderStatusInfo.OrderCouldNotBeCancelledBecauseItIsAlreadyCancelled;
            }

            if (order.OrderStatus == OrderStatus.Cancelled)
            {
                return OrderStatusInfo.OrderCouldNotBeCancelledBecauseItIsAlreadyRefunded;
            }


            await repo.UpdateOrderStatus(orderDto.OrderId, OrderStatus.Cancelled);

            var cancelledOrder = mapper.Map<CancelledOrder>(orderDto);
            cancelledOrder.CancellationDate = DateTime.Now;

            await repo.CancelOrder(cancelledOrder);

            var status = await repo.SaveChange();

            return OrderStatusInfo.OrderCancelled;
        }

        public async Task<OrderStatusInfo> RefundOrder(int orderId)
        {
            var order = await repo.GetOrderById(orderId);

            if(order.OrderStatus != OrderStatus.Cancelled)
            {
                return OrderStatusInfo.OrderCouldNotBeRefundedBecauseItIsNotCancelled;
            }
            await repo.UpdateOrderStatus(orderId, OrderStatus.Refunded);

            var refundedOrder = new RefundedOrder
            {
                OrderId = orderId,
                RefundedAmount = order.TotalPrice,
                RefundDate = DateTime.Now
            };

            await repo.RefundOrder(refundedOrder);

            await repo.SaveChange();

            return OrderStatusInfo.OrderRefunded;
        }

        public async Task<RefundedOrderDto> GetRefundedOrder(int orderId)
        {
            RefundedOrder refundedOrder = await repo.GetRefundedOrder(orderId);

            var refundedOrderDto = mapper.Map<RefundedOrderDto>(refundedOrder);

            return refundedOrderDto;
        }
    }
}
