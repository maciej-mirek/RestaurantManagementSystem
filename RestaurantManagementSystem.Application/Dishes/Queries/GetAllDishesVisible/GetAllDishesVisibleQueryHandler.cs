using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Queries.GetAllDishesVisible
{
    public class GetAllDishesVisibleQueryHandler : IRequestHandler<GetAllDishesVisibleQuery, List<Dish>>
    {
        private readonly IDishRepository _dishRepository;

        public GetAllDishesVisibleQueryHandler(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public async Task<List<Dish>> Handle(GetAllDishesVisibleQuery request, CancellationToken cancellationToken)
        {
            return _dishRepository.GetVisibleDishes();
        }
    }
}
