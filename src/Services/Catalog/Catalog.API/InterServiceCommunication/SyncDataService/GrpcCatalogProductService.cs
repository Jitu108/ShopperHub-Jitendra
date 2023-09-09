using AutoMapper;
using Catalog.API.ProtoService;
using Catalog.API.Services;
using Grpc.Core;

namespace Catalog.API.InterServiceCommunication.SyncDataService
{
    public class GrpcCatalogProductService : GrpcCatalogProductProvider.GrpcCatalogProductProviderBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public GrpcCatalogProductService(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public override async Task<GrpcCatalogProductList> GrpcGetAllProductsLean(GrpcEmptyRequest request, ServerCallContext context)
        {
            var products = await productService.GetAllProductsAsync();
            var productList = mapper.Map<List<GrpcCatalogProduct>>(products);
            var response = new GrpcCatalogProductList();
            productList.ForEach(x => response.Products.Add(x));

            return response;
        }

        public override async Task<GrpcCatalogProductDetailedList> GrpcGetAllProducts(GrpcEmptyRequest request, ServerCallContext context)
        {
            var products = await productService.GetAllProductsAsync();
            var productList = mapper.Map<List<GrpcCatalogProductDetailed>>(products);
            var response = new GrpcCatalogProductDetailedList();
            productList.ForEach(x => response.Products.Add(x));

            return response;
        }

        public override async Task<GrpcCatalogProductDetailedList> GrpcGetProductByBrandId(GrpcIdRequest request, ServerCallContext context)
        {
            var products = await productService.GetProductByBrandIdAsync(request.Id);
            var productList = mapper.Map<List<GrpcCatalogProductDetailed>>(products);
            var response = new GrpcCatalogProductDetailedList();
            productList.ForEach(x => response.Products.Add(x));

            return response;
        }

        public override async Task<GrpcCatalogProductDetailedList> GrpcGetProductByCatalogTypeId(GrpcIdRequest request, ServerCallContext context)
        {
            var products = await productService.GetProductByCatalogTypeIdAsync(request.Id);
            var productList = mapper.Map<List<GrpcCatalogProductDetailed>>(products);
            var response = new GrpcCatalogProductDetailedList();
            productList.ForEach(x => response.Products.Add(x));

            return response;
        }

        public override async Task<GrpcCatalogProductDetailedList> GrpcGetProductById(GrpcIdRequest request, ServerCallContext context)
        {
            var products = await productService.GetProductByIdAsync(request.Id);
            var productList = mapper.Map<List<GrpcCatalogProductDetailed>>(products);
            var response = new GrpcCatalogProductDetailedList();
            productList.ForEach(x => response.Products.Add(x));

            return response;
        }
    }
}
