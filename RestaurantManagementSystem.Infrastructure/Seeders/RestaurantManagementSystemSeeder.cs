using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Seeders
{
    public class RestaurantManagementSystemSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public RestaurantManagementSystemSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Orders.Any() || !_dbContext.Dishes.Any() || !_dbContext.OrderDishes.Any())
                {
                    var dish1 = new Dish { Name = "Spaghetti Bolognese", Price = 25.0m, EstimatedTime = 30, IsVisible = true };
                    var dish2 = new Dish { Name = "Caesar Salad", Price = 20.0m, EstimatedTime = 15, IsVisible = true };
                    var dish3 = new Dish { Name = "Chicken Curry", Price = 30.0m, EstimatedTime = 25, IsVisible = true };

                    var address = new Address
                    {
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        City = "Warszawa",
                        Street = "Krakowska",
                        HouseNumber = "12a",
                        PostalCode = "00-000",
                        PhoneNumber = "123456789"
                    };
                    var address2 = new Address
                    {
                        FirstName = "Anna",
                        LastName = "Nowak",
                        City = "Poznań",
                        Street = "Lecha",
                        HouseNumber = "3b",
                        PostalCode = "61-244",
                        PhoneNumber = "987654321"
                    };

                    var order = new Order
                    {
                        IsPaid = true,
                        TotalPrice = 45.0m,
                        DeliveryPrice = 5.0m,
                        OrderTime = DateTime.Now,
                        DeliveryType = DeliveryTypeEnum.ToAdress,
                        PaymentType = PaymentTypeEnum.Online,
                        Address = address,
                    };

                    var order2 = new Order
                    {
                        IsPaid = false,
                        TotalPrice = 55.0m,
                        DeliveryPrice = 5.0m,
                        OrderTime = DateTime.Now.AddHours(-1),
                        DeliveryType = DeliveryTypeEnum.Local,
                        PaymentType = PaymentTypeEnum.OnDelivery,
                        TableNumber = 1,
                        Address = address2,
                    };

                    var orderDishes1 = new OrderDishes { OrderId = 1, Order = order, DishId = 1, Dish = dish1, Quantity = 2 };
                    var orderDishes2 = new OrderDishes { OrderId = 1, Order = order, DishId = 2, Dish = dish2, Quantity = 1};
                    var orderDishes3 = new OrderDishes { OrderId = 2, Order = order2, DishId = 1, Dish = dish1, Quantity = 3 };
                    var orderDishes4 = new OrderDishes { OrderId = 2, Order = order2, DishId = 3, Dish = dish3, Quantity = 1 };

                    var orderStatus1 = new OrderStatus { Active= true, Status = StatusEnum.New, Order = order, Time = DateTime.UtcNow };
                    var orderStatus2 = new OrderStatus { Active= true, Status = StatusEnum.New, Order = order2, Time = DateTime.UtcNow };

                    await _dbContext.Orders.AddRangeAsync(order, order2);
                    await _dbContext.OrderDishes.AddRangeAsync(orderDishes1, orderDishes2, orderDishes3, orderDishes4);
                    await _dbContext.OrderStatuses.AddRangeAsync(orderStatus1, orderStatus2);

                    await _dbContext.SaveChangesAsync();
                }
            }

        }
    }
}
