﻿using UserBff.Dtos;

namespace UserBff.Services
{
    public interface ICatalogProductService
    {
        //Task<bool> AddProductAsync(Product product);
        Task<ProductRead> GetProductByIdAsync(long productId);
        Task<IEnumerable<ProductRead>> GetProductByBrandIdAsync(long catalogBrandId);
        Task<IEnumerable<ProductRead>> GetProductByCatalogTypeIdAsync(long catalogtypeId);
        Task<IEnumerable<ProductRead>> GetAllProductsAsync();
        Task<bool> AddProductAsync(ProductCreate product);
        Task<bool> UpdateProductAsync(ProductCreate product);
        Task<bool> DeleteProductAsync(long productId);
        
    }
}
