using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantManagementSystem.Application.Users.Command.Login
{
    public class LoginCommand : UserLoginRequest,IRequest<AuthResult>
    {
    }
}
