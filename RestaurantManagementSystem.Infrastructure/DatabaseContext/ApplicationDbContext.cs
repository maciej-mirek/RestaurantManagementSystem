using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDishes> OrderDishes { get; set; }
        public DbSet<Address> Addresses{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasMany(o => o.Dishes);

            builder.Entity<OrderDishes>()
                .HasKey(od => od.OrderDishesId);

            builder.Entity<OrderDishes>()
                .HasOne(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.OrderId);

            builder.Entity<OrderDishes>()
                .HasOne(od => od.Dish)
                .WithMany()
                .HasForeignKey(od => od.DishId);
        }
    }
}
