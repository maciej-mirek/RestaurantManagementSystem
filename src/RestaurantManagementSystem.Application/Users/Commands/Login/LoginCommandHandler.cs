using MediatR;
using Microsoft.AspNetCore.Identity;
using RestaurantManagementSystem.Domain.Exceptions;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<IdentityUser<int>> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }
        public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser is null)
            {
                return new AuthResult()
                {
                    Result = false,
                    Errors = new List<string> { "Incorrect username or password." }
                };
            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);

            if (!isCorrect)
            {
                return new AuthResult()
                {
                    Result = false,
                    Errors = new List<string> { "Incorrect username or password." }
                };
            }

            var jwtToken = await _jwtProvider.GenerateJwtToken(existingUser);

            return new AuthResult()
            {
                Result = true,
                Token = jwtToken
            };
        }
    }
}
