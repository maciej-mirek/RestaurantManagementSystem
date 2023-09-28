using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task Create(Order order)
        {

            foreach(var d in order.Dishes)
            {
                var dish = await _dbContext.Dishes.FindAsync(d.DishId);
                if (dish is null)
                    throw new Exception();
            }

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public List<Order> GetActive() => _dbContext.Orders
            .Include(o => o.Dishes)
            .ThenInclude(o => o.Dish).ToList();
    }
}
