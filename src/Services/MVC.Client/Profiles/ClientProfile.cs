using AutoMapper;
using MVC.Client.Models;

namespace MVC.Client.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Product, CatalogProduct>()
                .ForMember(dest => dest.OfferPrice, option => option.MapFrom(src => src.DiscountedPrice));
        }
    }
}
