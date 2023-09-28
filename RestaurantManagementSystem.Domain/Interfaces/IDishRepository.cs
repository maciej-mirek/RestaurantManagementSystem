using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Interfaces
{
    public interface IDishRepository
    {
        List<Dish> GetDishes();
        List<Dish> GetVisibleDishes();
        Task CreateDish(Dish dish);
        Task ChangeVisibility(int dishId, bool visibility);
        Task Archive(int dishId);
    }
}
