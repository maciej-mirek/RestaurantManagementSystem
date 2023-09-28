using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Interfaces
{
    public interface IOrderStatusesRepository
    {
        List<OrderStatus> GetNotCompletedOrdersWithStatus();
        List<OrderStatus> GetNotCompletedOrdersWithStatusWaiter();
        Task ChangeStatus(int orderId, StatusEnum status, int? userId);

    }
}
