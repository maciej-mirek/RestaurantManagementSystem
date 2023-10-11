using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int EstimatedTime { get; set; }
        public bool IsVisible { get; set; }
        public bool IsArchived { get; set; } = false;
        public List<OrderDishes> OrderDishes { get; set; }
    }
}
