using AutoMapper;
using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogBrandController : ControllerBase
    {
        private readonly ICatalogBrandService brandService;
        private readonly IMapper mapper;

        public CatalogBrandController(
            ICatalogBrandService brandService,
            IMapper mapper
            )
        {
            this.brandService = brandService;
            this.mapper = mapper;
        }

        [HttpPost("Add", Name = "AddBrand")]
        public async Task<ActionResult<bool>> AddBrand(CatalogBrandCreate brand)
        {
            var brandModel = mapper.Map<CatalogBrand>(brand);
            var status = await brandService.AddCatalogBrandAsync(brandModel);
            return Ok(status);
        }

        [HttpPut("Update", Name = "UpdateBrand")]
        public async Task<ActionResult<bool>> UpdateBrand(CatalogBrandUpdate brand)
        {
            var brandModel = mapper.Map<CatalogBrand>(brand);
            var status = await brandService.UpdateCatalogBrandAsync(brandModel);
            return Ok(status);
        }

        [HttpDelete("Delete/{brandId}", Name = "DeleteBrand")]
        public async Task<ActionResult<bool>> DeleteBrand(int brandId)
        {
            var status = await brandService.DeleteCatalogBrandAsync(brandId);
            return Ok(status);
        }

        [HttpGet("GetAll", Name = "GetAllBrands")]
        public async Task<ActionResult<IEnumerable<CatalogBrandRead>>> GetAllBrands()
        {
            var brands = await brandService.GetCatalogBrandsAsync();
            var brandsDto = mapper.Map<IEnumerable<CatalogBrandRead>>(brands);
            return Ok(brandsDto);
        }

        [HttpGet("ById/{brandId}", Name = "GetBrandById")]
        public async Task<ActionResult<CatalogBrandRead>> GetBrandById(int brandId)
        {
            var brand = await brandService.GetCatalogBrandByIdAsync(brandId);
            var brandDto = mapper.Map<CatalogBrandRead>(brand);
            return Ok(brandDto);
        }
    }
}
