using Catalog.API.Data.Interface;
using Catalog.API.Entities;

namespace Catalog.API.Services
{
    public class CatalogBrandService : ICatalogBrandService
    {
        private readonly ICatalogBrandRepo brandRepo;

        public CatalogBrandService(ICatalogBrandRepo brandRepo)
        {
            this.brandRepo = brandRepo;
        }

        public Task<bool> AddCatalogBrandAsync(CatalogBrand brand)
        {
            return brandRepo.AddCatalogBrandAsync(brand);
        }

        public Task<bool> UpdateCatalogBrandAsync(CatalogBrand brand)
        {
            return brandRepo.UpdateCatalogBrandAsync(brand);
        }

        public Task<bool> DeleteCatalogBrandAsync(int brandId) =>
        brandRepo.DeleteCatalogBrandAsync(brandId);

        public Task<CatalogBrand> GetCatalogBrandByIdAsync(int catalogBrandId) =>
        brandRepo.GetCatalogBrandByIdAsync(catalogBrandId);

        public Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync() =>
        brandRepo.GetCatalogBrandsAsync();
    }
}