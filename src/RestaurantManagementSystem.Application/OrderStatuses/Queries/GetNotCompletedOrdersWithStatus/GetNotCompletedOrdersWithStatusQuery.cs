using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.OrderStatuses.Queries.GetNotCompletedOrdersWithStatus
{
    public class GetNotCompletedOrdersWithStatusQuery : IRequest<List<OrderStatus>>
    {
    }
}
