using Catalog.API.Data.Interface;
using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly ICatalogTypeRepo typeRepo;

        public CatalogTypeService(ICatalogTypeRepo typeRepo)
        {
            this.typeRepo = typeRepo;
        }

        public Task<bool> AddCatalogTypeAsync(CatalogType catalogType) =>
        typeRepo.AddCatalogTypeAsync(catalogType);

        public Task<bool> UpdateCatalogTypeAsync(CatalogType type) =>
        typeRepo.UpdateCatalogTypeAsync(type);

        public Task<bool> DeleteCatalogTypeAsync(int typeId) =>
        typeRepo.DeleteCatalogTypeAsync(typeId);

        public Task<CatalogType> GetCatalogTypeByIdAsync(int catalogtypeId) =>
        typeRepo.GetCatalogTypeByIdAsync(catalogtypeId);

        public Task<IEnumerable<CatalogType>> GetCatalogTypesAsync() =>
        typeRepo.GetCatalogTypesAsync();
    }
}