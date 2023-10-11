using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommand : DishDto,IRequest
    {
    }
}
