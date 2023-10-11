using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.OrderStatuses.Commands.ChangeOrderStatus;
using RestaurantManagementSystem.Application.OrderStatuses.Queries.GetNotCompletedOrdersWithStatus;
using RestaurantManagementSystem.Application.OrderStatuses.Queries.GetNotCompletedOrdersWithStatusWaiter;

namespace RestaurantManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderStatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetNotCompletedWithStatus")]
        public async Task<IActionResult> GetNotCompletedOrdersWithStatus()
        {
            return Ok(await _mediator.Send(new GetNotCompletedOrdersWithStatusQuery()));
        }

        [HttpGet("GetNotCompletedWithStatusWaiter")]
        public async Task<IActionResult> GetNotCompletedOrdersWithStatusWaiter()
        {
            return Ok(await _mediator.Send(new GetNotCompletedOrdersWithStatusWaiterQuery()));
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusCommand status)
        {
            await _mediator.Send(new ChangeOrderStatusCommand());
            return Ok();
        }
    }
}
