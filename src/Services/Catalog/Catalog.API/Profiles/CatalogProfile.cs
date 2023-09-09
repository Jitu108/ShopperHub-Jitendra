using AutoMapper;
using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.ProtoService;
using System.Text;

namespace Catalog.API.Profiles
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<CatalogBrandCreate, CatalogBrand>();
            CreateMap<CatalogBrand, CatalogBrandRead>();


            CreateMap<CatalogBrandUpdate, CatalogBrand>();

            CreateMap<CatalogTypeCreate, CatalogType>();
            CreateMap<CatalogType, CatalogTypeRead>();
            CreateMap<CatalogTypeUpdate, CatalogType>();

            CreateMap<ProductCreate, Product>();
            CreateMap<ProductCreate, Image>()
            .ForMember(dest => dest.ProductId, option => option.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, option => option.MapFrom(src => src.ImageId))
            .ForMember(dest => dest.Name, option => option.MapFrom(src => src.ImageName))
            .ForMember(dest => dest.Caption, option => option.MapFrom(src => src.ImageCaption))
            .ForMember(dest => dest.Data, option => option.MapFrom(src => src.ImageData != null ? Encoding.ASCII.GetBytes(src.ImageData) : Array.Empty<byte>()));

            CreateMap<Product, ProductRead>()
            .ForMember(dest => dest.ImageId, option => option.MapFrom(src => src.Image.Id))
            .ForMember(dest => dest.ImageName, option => option.MapFrom(src => src.Image.Name))
            .ForMember(dest => dest.ImageCaption, option => option.MapFrom(src => src.Image.Caption))
            .ForMember(dest => dest.ImageData, option => option.MapFrom(src => Encoding.UTF8.GetString(src.Image.Data)))
            .ForMember(dest => dest.CatalogBrand, option => option.MapFrom(src => src.CatalogBrand.Brand))
            .ForMember(dest => dest.CatalogType, option => option.MapFrom(src => src.CatalogType.Type));

            // GRPC Mappings
            CreateMap<ProductRead, GrpcCatalogProduct>()
                .ForMember(dest => dest.ProductId, option => option.MapFrom(src => src.Id));
        }
    }
}
