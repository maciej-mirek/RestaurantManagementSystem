using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetUserOrders(int userId);
        Task Create(Order order);
    }
}
