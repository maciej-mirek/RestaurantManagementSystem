using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Users.Commands.Register
{
    public class RegisterCommand : UserRegistrationRequest, IRequest<AuthResult>
    {
    }
}
