using Microsoft.AspNetCore.Identity;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Orders
{
    public class OrderDto
    {
        public bool IsPaid { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public DeliveryTypeEnum DeliveryType { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int? TableNumber { get; set; }
        public string? AdditionalInfo { get; set; }
        public IdentityUser? User { get; set; }
        public Address? Address { get; set; }
        public List<OrderDishesDto> Dishes { get; set; }
    }
}
