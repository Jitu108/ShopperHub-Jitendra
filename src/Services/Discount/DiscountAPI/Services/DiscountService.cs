using DiscountAPI.Data.Interface;
using DiscountAPI.Entities;

namespace DiscountAPI.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepo discountRepo;

        public DiscountService(IDiscountRepo discountRepo)
        {
            this.discountRepo = discountRepo;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            return await discountRepo.AddProductAsync(product);
        }

        public async Task AddProductsAsync(IList<Product> products)
        {
            var productsList = await discountRepo.GetProductsAsync();
            var productIds = productsList.Select(x => x.ProductExternalId).ToList();

            var productsToAdd = new List<Product>();
            var productsToUpdate = new List<Product>();
            foreach (var product in products)
            {
                // If Product does not exist, Add
                if (!productIds.Contains(product.ProductExternalId))
                {
                    product.DiscountFlat = 0;
                    productsToAdd.Add(product);
                }

                // If Product exist, but name or MRP updated, Update
                else
                {
                    var existingProduct = productsList.FirstOrDefault(x => x.ProductExternalId == product.ProductExternalId);
                    if (existingProduct != null
                        && (product.Name != existingProduct.Name || product.MRP != existingProduct.MRP))
                    {
                        productsToUpdate.Add(product);
                    }
                }
            }

            await discountRepo.AddProductsAsync(productsToAdd);
            await discountRepo.UpdateProductsAsync(productsToUpdate);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await discountRepo.GetProductsAsync();
        }

        public async Task<bool> UpdateDiscountAsync(int productId, decimal discount, bool isPrecent)
        {
            return await discountRepo.UpdateDiscountAsync(productId, discount, isPrecent);
        }
    }
}
