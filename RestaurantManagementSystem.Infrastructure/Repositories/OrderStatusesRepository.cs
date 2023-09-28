using Microsoft.EntityFrameworkCore;
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
    public class OrderStatusesRepository : IOrderStatusesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderStatusesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<OrderStatus> GetNotCompletedOrdersWithStatus() => 
            _dbContext.OrderStatuses
            .Where(os => os.Status != StatusEnum.Completed && os.Status != StatusEnum.Cancelled && os.Active)
            .Include(os => os.Order)
            .ToList();


        public List<OrderStatus> GetNotCompletedOrdersWithStatusWaiter() =>
            _dbContext.OrderStatuses
            .Where(os => os.Status == StatusEnum.Ready_to_serve)
            .Include(os => os.Order)
            .ToList();
        public async Task ChangeStatus(int orderId, StatusEnum status, int? userId)
        {
            if (status != StatusEnum.New)
            {
                var orderStatus = _dbContext.OrderStatuses
                    .FirstOrDefault(s => s.Order.OrderId == orderId && s.Active == true);

                if (orderStatus is null)
                    throw new NotFoundException("Order not found");

                orderStatus.Active = false;

                _dbContext.OrderStatuses.Update(orderStatus);
            }

            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            //var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            var newStatus = new OrderStatus
            {
                Order = order,
                Status = status,
                User = null,
                Time = DateTime.Now,
                Active = true,
            };
            await _dbContext.OrderStatuses.AddAsync(newStatus);
            await _dbContext.SaveChangesAsync();
        }
    }
}
