using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Queries.GetAllDishesVisible
{
    public class GetAllDishesVisibleQuery : IRequest<List<Dish>>
    {
    }
}
