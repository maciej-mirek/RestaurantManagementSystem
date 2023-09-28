using RestaurantManagementSystem.Application.Exceptions;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using RestaurantManagementSystem.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DishRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;  
        }
        public List<Dish> GetDishes() => _dbContext.Dishes.ToList();
        public List<Dish> GetVisibleDishes() => _dbContext.Dishes.Where(d=> d.IsVisible).ToList();
        public async Task CreateDish(Dish dish)
        {
            Dish newDish = new Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                IsVisible = dish.IsVisible,
                EstimatedTime = dish.EstimatedTime,
            };

            await _dbContext.Dishes.AddAsync(newDish);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Archive(int dishId)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if (dish is null)
                throw new NotFoundException("Dish not found");

            dish.IsArchived = true;
            _dbContext.Dishes.Update(dish);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeVisibility(int dishId, bool visibility)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if (dish is null)
                throw new NotFoundException("Dish not found");

            dish.IsVisible = visibility;

            _dbContext.Dishes.Update(dish);
            await _dbContext.SaveChangesAsync();
        }


    }
}
