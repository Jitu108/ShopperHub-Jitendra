using Catalog.API.Dtos;
using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public interface ICatalogTypeService
    {
        Task<bool> AddCatalogTypeAsync(CatalogTypeCreate catalogType);
        Task<bool> UpdateCatalogTypeAsync(CatalogTypeUpdate type);
        Task<bool> DeleteCatalogTypeAsync(int typeId);
        Task<CatalogTypeRead> GetCatalogTypeByIdAsync(int catalogtypeId);
        Task<IEnumerable<CatalogTypeRead>> GetCatalogTypesAsync();
    }
}