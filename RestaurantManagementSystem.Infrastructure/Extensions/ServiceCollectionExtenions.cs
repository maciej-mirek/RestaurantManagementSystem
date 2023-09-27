using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Application.Config;
using RestaurantManagementSystem.Domain.Interfaces;
using RestaurantManagementSystem.Infrastructure.Authentication;
using RestaurantManagementSystem.Infrastructure.DbContext;
using RestaurantManagementSystem.Infrastructure.Repositories;
using RestaurantManagementSystem.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtenions
    {
        public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("RestaurantManagementSystem")));
            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
            services.AddScoped<RestaurantManagementSystemSeeder>();

            services.AddScoped<IDishRepository,DishRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();



        }
    }
}
