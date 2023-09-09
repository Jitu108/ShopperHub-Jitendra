using AutoMapper;
using Catalog.API.Data.Interface;
using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.RedisConfig;
using Microsoft.Extensions.Caching.Distributed;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;
        private readonly IDistributedCache cache;

        public ProductService(
            IProductRepo productRepo,
            IMapper mapper,
            IDistributedCache distributedCache)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
            this.cache = distributedCache;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var status = await productRepo.AddProductAsync(product);

            return status;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            if (product.Id == 0) return false;
            var isProductExist = await productRepo.IsProductExist(product.Id);
            if (!isProductExist) return false;

            var status = await productRepo.UpdateProductAsync(product);

            return status;
        }

        public async Task<bool> DeleteProductAsync(long productId)
        {
            var status = await productRepo.DeleteProductAsync(productId);

            return status;
        }
        

        public async Task<IEnumerable<ProductRead>> GetAllProductsAsync()
        {
            var data = await productRepo.GetAllProductsAsync();
            var productDto = mapper.Map<IEnumerable<ProductRead>>(data);

            return productDto;
        }

        public async Task<IEnumerable<ProductRead>> GetProductByBrandIdAsync(long catalogBrandId)
        {
            var data = await productRepo.GetProductByBrandIdAsync(catalogBrandId);
            var productDto = mapper.Map<IEnumerable<ProductRead>>(data);

            return productDto;
        }

        public async Task<IEnumerable<ProductRead>> GetProductByCatalogTypeIdAsync(long catalogtypeId)
        {
            var data = await productRepo.GetProductByCatalogTypeIdAsync(catalogtypeId);
            var productDto = mapper.Map<IEnumerable<ProductRead>>(data);

            return productDto;
        }

        public async Task<ProductRead> GetProductByIdAsync(long productId)
        {
            var data = await productRepo.GetProductByIdAsync(productId);
            var productDto = mapper.Map<ProductRead>(data);

            return productDto;
        }

        public  async Task UpdateProductsPriceAsync(List<Product> products)
        {
            await productRepo.UpdateProductsPriceAsync(products);
        }
    }
}