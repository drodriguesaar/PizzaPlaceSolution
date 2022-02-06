using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Shared;

namespace PizzaPlace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaBusiness _pizzaBusiness;
        public PizzasController(IPizzaBusiness pizzaBusiness)
        {
            _pizzaBusiness = pizzaBusiness;
        }

        [HttpGet("/pizzas")]
        public IQueryable<Pizza> GetPizzas() => _pizzaBusiness.GetAll();

        [HttpPost("/pizza")]
        public async Task<IActionResult> InsertPizza([FromBody] Pizza pizza)
        {
            pizza = await _pizzaBusiness.Create(pizza);
            return Created($"pizzas/{pizza.Id}", pizza);
        }

    }
}
