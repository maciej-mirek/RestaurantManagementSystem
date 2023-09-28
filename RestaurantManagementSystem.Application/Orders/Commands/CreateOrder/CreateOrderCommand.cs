using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderDto,IRequest
    {
    }
}
