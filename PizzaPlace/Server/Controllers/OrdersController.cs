using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Shared;

namespace PizzaPlace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("/order")]
        public async Task<IActionResult> InsertOrder([FromBody] ShoppingBasket basket)
        {
            var order = await _orderService.PlaceOrder(basket);
            return Created("/order", order.Id);
        }

        [HttpGet("/orders/{id:int}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            return Ok(order);
        }
    }
}
