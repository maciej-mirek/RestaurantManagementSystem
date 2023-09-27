using MediatR;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.ChangeDishVisibility
{
    public class ChangeDishVisibilityCommandHandler : IRequestHandler<ChangeDishVisibilityCommand>
    {
        private readonly IDishRepository _dishRepository;

        public ChangeDishVisibilityCommandHandler(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public async Task Handle(ChangeDishVisibilityCommand request, CancellationToken cancellationToken)
        {
            await _dishRepository.ChangeVisibility(request.DishId);
        }
    }
}
