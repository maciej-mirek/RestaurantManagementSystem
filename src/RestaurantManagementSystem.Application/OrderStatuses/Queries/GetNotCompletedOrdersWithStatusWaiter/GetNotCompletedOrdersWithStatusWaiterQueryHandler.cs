using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.OrderStatuses.Queries.GetNotCompletedOrdersWithStatusWaiter
{
    public class GetNotCompletedOrdersWithStatusWaiterQueryHandler : IRequestHandler<GetNotCompletedOrdersWithStatusWaiterQuery, List<OrderStatus>>
    {
        private readonly IOrderStatusesRepository _orderStatusesRepository;
        public GetNotCompletedOrdersWithStatusWaiterQueryHandler(IOrderStatusesRepository orderStatusesRepository)
        {
            _orderStatusesRepository = orderStatusesRepository;
        }
        public async Task<List<OrderStatus>> Handle(GetNotCompletedOrdersWithStatusWaiterQuery request, CancellationToken cancellationToken)
        {
            return _orderStatusesRepository.GetNotCompletedOrdersWithStatusWaiter();
        }
    }
}
