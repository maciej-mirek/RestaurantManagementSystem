using MediatR;
using Microsoft.AspNetCore.Identity;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Users.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResult>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterCommandHandler(IJwtProvider jwtProvider, UserManager<IdentityUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist is not null)
            {
                bool hasPassword = await _userManager.HasPasswordAsync(userExist);
                if (hasPassword)
                    return new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string> { "Account with this email already exists." }
                    };
            }
            var newUser = new IdentityUser()
            {
                Email = request.Email,
                UserName = request.Email,
            };
            var isCreated = await _userManager.CreateAsync(newUser, request.Password);
            if (isCreated.Succeeded)
            {
                var token = await _jwtProvider.GenerateJwtToken(newUser);
                return new AuthResult() { Result = true, Token = token };
            }
            var errors = new List<string>();
            foreach (var error in isCreated.Errors)
            {
                errors.Add(error.Description);
            }

            return new AuthResult() { Result = false, Errors = errors };
        }
    }
}
