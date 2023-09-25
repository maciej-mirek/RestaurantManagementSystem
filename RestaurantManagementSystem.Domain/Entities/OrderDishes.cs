using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Entities
{
    public class OrderDishes
    {
        public int OrderDishesId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
