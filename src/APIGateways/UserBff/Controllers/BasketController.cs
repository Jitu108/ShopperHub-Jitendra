using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserBff.Dtos;
using UserBff.Services;

namespace UserBff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IMapper mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            this.basketService = basketService;
            this.mapper = mapper;
        }

        [HttpGet("{userId}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCartDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartDto>> GetBasket(int userId)
        {
            var basket = await basketService.GetBasket(userId);
            return Ok(basket ?? new ShoppingCartDto(userId));
        }

        [HttpPost("{userId}", Name = "UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCartDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartDto>> UpdateBasket(int userId, [FromBody] ShoppingCartItemCreate item)
        {
            var itemModel = mapper.Map<ShoppingCartItemDto>(item);

            return Ok(await basketService.UpdateBasket(userId, itemModel));
        }

        [HttpDelete("{userId}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket(int userId)
        {
            var status = await basketService.DeleteBasket(userId);
            return Ok(status);
        }
    }
}
