using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public StatusEnum Status { get; set; }
        public IdentityUser<int>? User { get; set; }
        public bool Active { get; set; }
        public DateTime Time { get; set; }
    }
}
