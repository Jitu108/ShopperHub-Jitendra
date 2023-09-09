using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public interface ICatalogBrandService
    {
        Task<bool> AddCatalogBrandAsync(CatalogBrand brand);
        Task<bool> UpdateCatalogBrandAsync(CatalogBrand brand);
        Task<bool> DeleteCatalogBrandAsync(int brandId);
        Task<CatalogBrand> GetCatalogBrandByIdAsync(int catalogBrandId);
        Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync();
    }
}