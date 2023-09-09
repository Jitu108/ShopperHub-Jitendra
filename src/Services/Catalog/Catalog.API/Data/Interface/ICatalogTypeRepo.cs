using Catalog.API.Entities;

namespace Catalog.API.Data.Interface
{
    public interface ICatalogTypeRepo
    {
        Task<bool> AddCatalogTypeAsync(CatalogType catalogType);
        Task<bool> UpdateCatalogTypeAsync(CatalogType catalogType);
        Task<bool> DeleteCatalogTypeAsync(int typeId);
        Task<CatalogType> GetCatalogTypeByIdAsync(int catalogtypeId);
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync();
    }
}
