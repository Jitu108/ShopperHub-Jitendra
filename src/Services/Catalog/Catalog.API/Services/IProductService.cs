using Catalog.API.Dtos;
using Catalog.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        
        Task<ProductRead> GetProductByIdAsync(long productId);
        Task<IEnumerable<ProductRead>> GetProductByBrandIdAsync(long catalogBrandId);
        Task<IEnumerable<ProductRead>> GetProductByCatalogTypeIdAsync(long catalogtypeId);
        Task<IEnumerable<ProductRead>> GetAllProductsAsync();

        Task<bool> AddProductAsync(ProductCreate productCreateDto);
        Task<bool> UpdateProductAsync(ProductCreate product);
        Task<bool> DeleteProductAsync(long productId);
    }
}