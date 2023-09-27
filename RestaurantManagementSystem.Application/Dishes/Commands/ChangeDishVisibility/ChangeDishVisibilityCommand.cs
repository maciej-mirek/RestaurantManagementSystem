using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.ChangeDishVisibility
{
    public class ChangeDishVisibilityCommand : IRequest
    {
        public int DishId { get; set; }
    }
}
