using MediatR;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.OrderStatuses.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand>
    {
        private readonly IOrderStatusesRepository _orderStatusesRepository;

        public ChangeOrderStatusCommandHandler(IOrderStatusesRepository orderStatusesRepository)
        {
            _orderStatusesRepository = orderStatusesRepository;
        }
        public async Task Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            await _orderStatusesRepository.ChangeStatus(request.OrderId, request.Status, request.UserId);
        }
    }
}
