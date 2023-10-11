using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Users;
using MediatR;
using RestaurantManagementSystem.Application.Orders.Commands.CreateOrder;
using RestaurantManagementSystem.Application.Orders.Queries.GetUserOrders;

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
            var createdOrder = await _mediator.Send(order);
            if (createdOrder is not null)
            {
                var orderCreatedResponse = new
                {
                    Status = "success",
                    createdOrder.OrderId
                };

                return Created("", orderCreatedResponse);
            }
            return BadRequest();

        }

        [HttpGet("GetUserOrders/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            return Ok(await _mediator.Send(new GetUserOrdersQuery { UserId = userId }));
        }
    }
}
