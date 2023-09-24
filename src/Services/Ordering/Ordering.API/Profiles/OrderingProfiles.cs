using AutoMapper;
using Ordering.API.Data.Entities;
using Ordering.API.Dtos;
using Ordering.API.Enums;

namespace Ordering.API.Profiles
{
    public class OrderingProfiles  :Profile
    {
        public OrderingProfiles()
        {
            CreateMap<OrderCreate, Order>()
                .ForMember(dest => dest.PaymentMode, option => option.MapFrom(src => (PaymentMode)Enum.Parse(typeof(PaymentMode), src.PaymentMode)))
                .ForMember(dest => dest.Addresses, option => option.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.PaymentMode, option => option.MapFrom(src => src.PaymentMode.ToString()))
                .ForMember(dest => dest.OrderStatus, option => option.MapFrom(src => src.OrderStatus.ToString()));

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            CreateMap<OrderItemCreate, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<CancelledOrderDto, CancelledOrder>();
            CreateMap<CancelledOrder, CancelledOrderDto>();

            CreateMap<RefundedOrder, RefundedOrderDto>();
            CreateMap<RefundedOrderDto, RefundedOrder>();
        }
    }
}
