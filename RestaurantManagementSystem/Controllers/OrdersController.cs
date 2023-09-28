using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Users.Command.Login;
using RestaurantManagementSystem.Application.Users;
using MediatR;
using RestaurantManagementSystem.Application.Orders.Commands.CreateOrder;

namespace RestaurantManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrderCommand order)
        {
            await _mediator.Send(order);
            return Ok();
        }
    }
}
