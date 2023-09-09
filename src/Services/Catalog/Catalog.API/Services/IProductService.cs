using Catalog.API.Dtos;
using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product product);
        Task<ProductRead> GetProductByIdAsync(long productId);
        Task<IEnumerable<ProductRead>> GetProductByBrandIdAsync(long catalogBrandId);
        Task<IEnumerable<ProductRead>> GetProductByCatalogTypeIdAsync(long catalogtypeId);
        Task<IEnumerable<ProductRead>> GetAllProductsAsync();
        Task<bool> DeleteProductAsync(long productId);
        Task<bool> UpdateProductAsync(Product productModel);
        Task UpdateProductsPriceAsync(List<Product> products);
    }
}