using MediatR;
using RestaurantManagementSystem.Application.Exceptions;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Queries.GetAllDishes
{
    public class GetAllDishesQueryHandler : IRequestHandler<GetAllDishesQuery, List<Dish>>
    {
        private readonly IDishRepository _dishRepository;

        public GetAllDishesQueryHandler(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public async Task<List<Dish>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
        {
            return _dishRepository.GetDishes();
        }
    }
}
