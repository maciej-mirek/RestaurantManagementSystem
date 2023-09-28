using MediatR;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Orders.Queries.GetUserOrders
{
    public class GetUserOrdersQuery : IRequest<List<Order>>
    {
        public int UserId { get; set; }
    }
}
