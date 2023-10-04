using AutoMapper;
using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand>
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public CreateDishCommandHandler(IDishRepository dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {   
            var dish = _mapper.Map<Domain.Entities.Dish>(request);
            await _dishRepository.CreateDish(dish);
        }
    }
}
