using Catalog.API.Dtos;
using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public interface ICatalogBrandService
    {
        Task<bool> AddCatalogBrandAsync(CatalogBrandCreate brand);
        Task<bool> UpdateCatalogBrandAsync(CatalogBrandUpdate brand);
        Task<bool> DeleteCatalogBrandAsync(int brandId);
        Task<CatalogBrandRead> GetCatalogBrandByIdAsync(int catalogBrandId);
        Task<IEnumerable<CatalogBrandRead>> GetCatalogBrandsAsync();
    }
}