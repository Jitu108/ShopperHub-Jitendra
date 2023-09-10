using AutoMapper;
using Catalog.API.ProtoService;
using DiscountAPI.Dtos;
using DiscountAPI.Entities;
using DiscountAPI.ProtoService;

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

            CreateMap<GrpcDiscountUpdate, DiscountUpdateDto>()
                .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.IsPercent, options => options.MapFrom(src => src.IsPercent))
                .ForMember(dest => dest.Discount, options => options.MapFrom(src => src.Discount));

            CreateMap<ProductDiscount, GrpcProductDiscount>()
                .ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.DiscountFlat, options => options.MapFrom(src => src.DiscountFlat))
                .ForMember(dest => dest.DiscountPercent, options => options.MapFrom(src => src.DiscountPercent))
                .ForMember(dest => dest.IsDiscountPercent, options => options.MapFrom(src => src.IsDiscountPercent))
                .ForMember(dest => dest.Mrp, options => options.MapFrom(src => src.MRP))
                .ForMember(dest => dest.Price, options => options.MapFrom(src => src.Price));

            CreateMap<GrpcProductDiscount, ProductDiscount>()
                .ForMember(dest => dest.MRP, options => options.MapFrom(src => src.Mrp));
        }
    }
}
