using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.OrderStatuses.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommand : IRequest
    {
        public int OrderId { get; set; }
        public StatusEnum Status { get; set; }
        public int? UserId { get; set; }
    }
}
