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
        private readonly IOrderStatusesRepository _orderStatusesRepository;
        public OrderRepository(ApplicationDbContext dbContext, IOrderStatusesRepository orderStatusesRepository)
        {
            _dbContext = dbContext;
            _orderStatusesRepository = orderStatusesRepository;
        }

        public async Task Create(Order order)
        {

            foreach(var d in order.Dishes)
            {
                if(d.Quantity == 0)
                    throw new Exception();
                var dish = await _dbContext.Dishes.FindAsync(d.DishId);
                if (dish is null)
                    throw new Exception();
            }

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            await _orderStatusesRepository.ChangeStatus(order.OrderId, StatusEnum.New, null);

        }

        public List<Order> GetUserOrders(int userId) => _dbContext.Orders
            .Where(o => o.User.Id == userId)
            .Include(o => o.Dishes)
            .ThenInclude(o => o.Dish).ToList();
    }
}
