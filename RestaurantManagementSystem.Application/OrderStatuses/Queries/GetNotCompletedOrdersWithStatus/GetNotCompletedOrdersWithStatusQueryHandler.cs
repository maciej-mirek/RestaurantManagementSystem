using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.OrderStatuses.Queries.GetNotCompletedOrdersWithStatus
{
    public class GetNotCompletedOrdersWithStatusQueryHandler : IRequestHandler<GetNotCompletedOrdersWithStatusQuery, List<OrderStatus>>
    {
        private readonly IOrderStatusesRepository _orderStatusesRepository;
        public GetNotCompletedOrdersWithStatusQueryHandler(IOrderStatusesRepository orderStatusesRepository)
        {
            _orderStatusesRepository = orderStatusesRepository;
        }
        public async Task<List<OrderStatus>> Handle(GetNotCompletedOrdersWithStatusQuery request, CancellationToken cancellationToken)
        {
            return _orderStatusesRepository.GetNotCompletedOrdersWithStatus();
        }
    }
}
