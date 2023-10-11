using MediatR;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.ArchiveDish
{
    public class ArchiveDishCommandHandler : IRequestHandler<ArchiveDishCommand>
    {
        private readonly IDishRepository _dishRepository;

        public ArchiveDishCommandHandler(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public async Task Handle(ArchiveDishCommand request, CancellationToken cancellationToken)
        {
            await _dishRepository.Archive(request.DishId);
        }
    }
}
