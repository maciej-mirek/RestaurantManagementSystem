using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Dishes;
using RestaurantManagementSystem.Application.Dishes.Commands.CreateDish;
using RestaurantManagementSystem.Application.Dishes.Queries;
using RestaurantManagementSystem.Application.Exceptions;
using RestaurantManagementSystem.Application.Users;
using RestaurantManagementSystem.Application.Users.Command.Login;
using RestaurantManagementSystem.Application.Users.Command.Register;
using RestaurantManagementSystem.Domain.Interfaces;

namespace RestaurantManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDishRepository _dishRepository;
        private readonly IOrderRepository _orderRepository;
        public AuthenticationController(IMediator mediator, IDishRepository dishRepository,
            IOrderRepository orderRepository)
        {      
            _mediator = mediator;
            _dishRepository = dishRepository;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationRequest request)
        {
            return Ok(await _mediator.Send(new RegisterCommand() { Email = request.Email, Password = request.Password }));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            return Ok(await _mediator.Send(new LoginCommand() { Email = request.Email, Password = request.Password}));
        }


        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
           
            return Ok(_orderRepository.Get());
        }
    }
}
