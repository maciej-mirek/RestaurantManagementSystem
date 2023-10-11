using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.OrderStatuses.Queries.GetNotCompletedOrdersWithStatusWaiter
{
    public class GetNotCompletedOrdersWithStatusWaiterQuery : IRequest<List<OrderStatus>>
    {
    }
}
