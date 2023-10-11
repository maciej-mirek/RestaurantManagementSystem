using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Users;
using RestaurantManagementSystem.Application.Users.Commands.Login;
using RestaurantManagementSystem.Application.Users.Commands.Register;

namespace RestaurantManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {      
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegistrationRequest request)
        {
            var result = await _mediator.Send(new RegisterCommand() { Email = request.Email, Password = request.Password });
            return result.Result ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var result = await _mediator.Send(new LoginCommand() { Email = request.Email, Password = request.Password });
            return result.Result ? Ok(result) : BadRequest(result);
        }

    }
}
