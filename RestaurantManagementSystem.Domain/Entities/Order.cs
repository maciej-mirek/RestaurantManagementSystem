using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public DeliveryTypeEnum DeliveryType { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int? TableNumber { get; set; }
        public string? AdditionalInfo { get; set; }
        public IdentityUser<int>? User { get; set; }
        public Address? Address { get; set; }
        public List<OrderDishes> Dishes { get; set; }
    }
}
