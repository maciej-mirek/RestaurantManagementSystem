using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Dishes;
using RestaurantManagementSystem.Application.Dishes.Commands.ArchiveDish;
using RestaurantManagementSystem.Application.Dishes.Commands.ChangeDishVisibility;
using RestaurantManagementSystem.Application.Dishes.Commands.CreateDish;
using RestaurantManagementSystem.Application.Dishes.Queries.GetAllDishes;
using RestaurantManagementSystem.Application.Dishes.Queries.GetAllDishesVisible;

namespace RestaurantManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DishesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllDishesQuery()));
        }
        [HttpGet("Visible")]
        public async Task<IActionResult> GetVisible()
        {
            return Ok(await _mediator.Send(new GetAllDishesVisibleQuery()));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateDishCommand dishDto)
        {
            await _mediator.Send(dishDto);
            return Ok();
        }

        [HttpPatch("ChangeVisibility")]
        public async Task<IActionResult> ChangeVisibility(ChangeDishVisibilityCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPatch("Archive")]
        public async Task<IActionResult> Archive(int dishId)
        {
            await _mediator.Send(new ArchiveDishCommand{DishId = dishId});
            return Ok();
        }
    }
}
