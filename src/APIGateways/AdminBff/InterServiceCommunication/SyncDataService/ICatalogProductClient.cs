﻿using AdminBff.Dtos;

namespace AdminBff.InterServiceCommunication.SyncDataService
{
    public interface ICatalogProductClient
    {
        Task<ProductRead> GetProductByIdAsync(long productId);
        Task<IEnumerable<ProductRead>> GetProductByBrandIdAsync(long catalogBrandId);
        Task<IEnumerable<ProductRead>> GetProductByCatalogTypeIdAsync(long catalogtypeId);
        Task<IEnumerable<ProductRead>> GetAllProductsAsync();

        Task<bool> AddProductAsync(ProductCreate productCreateDto);
        Task<bool> UpdateProductAsync(ProductCreate productCreateDto);
        Task<bool> DeleteProductAsync(long productId);
    }
}
