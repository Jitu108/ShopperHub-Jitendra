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
    public class CatalogTypeController : ControllerBase
    {
        private readonly ICatalogTypeService typeService;
        private readonly IMapper mapper;

        public CatalogTypeController(ICatalogTypeService typeService, IMapper mapper)
        {
            this.typeService = typeService;
            this.mapper = mapper;
        }

        [HttpPost("Add", Name = "AddType")]
        public async Task<IActionResult> AddType(CatalogTypeCreate type)
        {
            var typeModel = mapper.Map<CatalogType>(type);
            await typeService.AddCatalogTypeAsync(typeModel);
            return Ok();
        }

        [HttpPut("Update", Name = "UpdateType")]
        public async Task<ActionResult<bool>> UpdateType(CatalogTypeUpdate type)
        {
            var typeModel = mapper.Map<CatalogType>(type);
            var status = await typeService.UpdateCatalogTypeAsync(typeModel);
            return Ok(status);
        }

        [HttpDelete("Delete/{typeId}", Name = "DeleteType")]
        public async Task<ActionResult<bool>> DeleteType(int typeId)
        {
            var status = await typeService.DeleteCatalogTypeAsync(typeId);
            return Ok(status);
        }

        [HttpGet("GetAll", Name = "GetAllTypes")]
        public async Task<ActionResult<IEnumerable<CatalogTypeRead>>> GetAllTypes()
        {
            var types = await typeService.GetCatalogTypesAsync();
            var typesDto = mapper.Map<IEnumerable<CatalogTypeRead>>(types);
            return Ok(typesDto);
        }

        [HttpGet("ById/{typeId}", Name = "GetTypeById")]
        public async Task<ActionResult<CatalogTypeRead>> GetTypeById(int typeId)
        {
            var type = await typeService.GetCatalogTypeByIdAsync(typeId);
            var typeDto = mapper.Map<CatalogTypeRead>(type);
            return Ok(typeDto);
        }
    }
}
