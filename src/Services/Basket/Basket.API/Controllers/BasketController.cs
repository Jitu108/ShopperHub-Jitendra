using AutoMapper;
using Basket.API.Data;
using Basket.API.Data.Entities;
using Basket.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IShoppingCartRepo repo;
        private readonly IMapper mapper;

        public BasketController(IShoppingCartRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet("{userId}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(int userId)
        {
            var basket = await repo.GetBasket(userId);
            return Ok(basket ?? new ShoppingCart(userId));
        }

        [HttpPost("{userId}", Name = "UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(int userId, [FromBody] ShoppingCartItemCreate item)
        {
            var itemModel = mapper.Map<ShoppingCartItem>(item);

            return Ok(await repo.UpdateBasket(userId, itemModel));
        }

        [HttpDelete("{userId}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket(int userId)
        {
            await repo.DeleteBasket(userId);
            return Ok();
        }

    }
}
