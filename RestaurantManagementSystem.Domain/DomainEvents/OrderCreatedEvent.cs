using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Domain.Common;

namespace RestaurantManagementSystem.Domain.DomainEvents
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get; set; }

        public string? UserEmail { get; set; }

        public OrderCreatedEvent(int orderId, string? userEmail)
        {
            OrderId = orderId;
            UserEmail = userEmail;
        }
    }
}
