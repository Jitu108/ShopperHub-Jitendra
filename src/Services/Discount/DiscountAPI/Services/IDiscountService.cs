using DiscountAPI.Entities;

namespace DiscountAPI.Services
{
    public interface IDiscountService
    {
        Task<bool> AddProductAsync(Product product);
        Task AddProductsAsync(IList<Product> products);
        Task<bool> UpdateDiscountAsync(int productId, decimal discount, bool isPrecent);
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
