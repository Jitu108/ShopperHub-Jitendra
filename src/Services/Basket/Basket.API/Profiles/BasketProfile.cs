using AutoMapper;
using Basket.API.Data.Entities;
using Basket.API.Dtos;

namespace Basket.API.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<ShoppingCartItemCreate, ShoppingCartItem>();
        }
    }
}