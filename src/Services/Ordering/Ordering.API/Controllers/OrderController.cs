using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ordering.API.Dtos;
using Ordering.API.Services;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("ByUserId/{userId}", Name = "GetOrdersByUserId")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserId(int userId)
        {
            var orders = await orderService.GetOrdersByUserId(userId);
            return Ok(orders);
        }

        [HttpGet("{id}", Name = "GetOrdersById")]
        public async Task<ActionResult<OrderDto>> GetOrdersById(int id)
        {
            var order = await orderService.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost("AddOrder", Name = "AddOrder")]
        public async Task<IActionResult> AddOrder(OrderCreate order)
        {
            var orderStatus = await orderService.AddOrder(order);
            return Ok(orderStatus);
        }

        [HttpPost("CancelOrder", Name = "CancelOrder")]
        public async Task<IActionResult> CancelOrder(CancelledOrderDto order)
        {
            var orderStatus = await orderService.CancelOrder(order);
            return Ok(orderStatus.ToString());
        }

        [HttpPost("RefundOrder", Name = "RefundOrder")]
        public async Task<IActionResult> RefundOrder(int orderId)
        {
            var orderStatus = await orderService.RefundOrder(orderId);
            return Ok(orderStatus.ToString());
        }

        [HttpGet("GetRefundedOrder/{orderId}", Name = "GetRefundedOrderByOrderId")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetRefundedOrderByOrderId(int orderId)
        {
            var order = await orderService.GetRefundedOrder(orderId);
            return Ok(order);
        }
    }
}
