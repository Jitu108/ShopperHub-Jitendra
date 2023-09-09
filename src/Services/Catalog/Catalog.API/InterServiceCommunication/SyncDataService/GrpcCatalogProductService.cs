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
    }
}
