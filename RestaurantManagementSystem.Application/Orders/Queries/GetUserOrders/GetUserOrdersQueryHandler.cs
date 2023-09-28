using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Orders.Queries.GetUserOrders
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetUserOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository= orderRepository;  
        }
        public async Task<List<Order>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetUserOrders(request.UserId);
        }
    }
}
