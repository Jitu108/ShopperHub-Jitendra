using AdminBff.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminBff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        [HttpGet("{userId}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCartDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartDto>> GetBasket(string userId)
        {
            //var basket = await repo.GetBasket(userId);
            //return Ok(basket ?? new ShoppingCart(userId));
            return Ok();
        }

        [HttpPost("{userId}", Name = "UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCartDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartDto>> UpdateBasket(string userId, [FromBody] ShoppingCartItemCreate item)
        {
            //var itemModel = mapper.Map<ShoppingCartItemDto>(item);

            //return Ok(await repo.UpdateBasket(userId, itemModel));

            return Ok();
        }

        [HttpDelete("{userId}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            //await repo.DeleteBasket(userId);
            return Ok();
        }
    }
}
