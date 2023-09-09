using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public interface ICatalogTypeService
    {
        Task<bool> AddCatalogTypeAsync(CatalogType catalogType);
        Task<bool> UpdateCatalogTypeAsync(CatalogType type);
        Task<bool> DeleteCatalogTypeAsync(int typeId);
        Task<CatalogType> GetCatalogTypeByIdAsync(int catalogtypeId);
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync();
    }
}