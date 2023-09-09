using AutoMapper;
using Catalog.API.ProtoService;
using DiscountAPI.Dtos;
using DiscountAPI.Entities;

namespace DiscountAPI.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<GrpcCatalogProduct, Product>()
                .ForMember(dest => dest.ProductExternalId, options => options.MapFrom(src => src.ProductId));

            //CreateMap<Product, GrpcDiscountProduct>()
            //    .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.ProductExternalId))
            //    .ForMember(dest => dest.Price, options => options.MapFrom(src => src.IsDiscountPercent ? src.MRP - src.MRP * src.DiscountPercent * 100 : src.MRP - src.DiscountFlat));

            //CreateMap<Product, GrpcDetailedDiscountProduct>()
            //    .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.ProductExternalId))
            //    .ForMember(dest => dest.DiscountId, options => options.MapFrom(src => src.Id));

            CreateMap<Product, ProductDiscount>()
                .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.ProductExternalId));
        }
    }
}
