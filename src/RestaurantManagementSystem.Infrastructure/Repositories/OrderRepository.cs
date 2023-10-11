using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Domain;
using RestaurantManagementSystem.Domain.DomainEvents;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using RestaurantManagementSystem.Infrastructure.DatabaseContext;
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
        private readonly IPublisher _publisher;
        public OrderRepository(ApplicationDbContext dbContext,IPublisher publisher)
        {
            _dbContext = dbContext;
            _publisher = publisher;
        }

        public async Task<Order> Create(Order order)
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

            await _publisher.Publish(new OrderCreatedEvent(order.OrderId,order.User is not null ? order.User.Email : "" ));

            return order;
        }

        public List<Order> GetUserOrders(int userId) => _dbContext.Orders
            .Where(o => o.User.Id == userId)
            .Include(o => o.Dishes)
            .ThenInclude(o => o.Dish).ToList();
    }
}
