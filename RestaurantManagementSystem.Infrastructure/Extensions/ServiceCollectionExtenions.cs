using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Domain.Interfaces;
using RestaurantManagementSystem.Infrastructure.Authentication;
using RestaurantManagementSystem.Infrastructure.DatabaseContext;
using RestaurantManagementSystem.Infrastructure.Repositories;
using RestaurantManagementSystem.Infrastructure.Seeders;
using RestaurantManagementSystem.Infrastructure.Services.Email;
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

            services.AddIdentityCore<IdentityUser<int>>()
                .AddRoles<IdentityRole<int>>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(jwt =>
              {
                  var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
                  jwt.SaveToken = true;
                  jwt.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      RequireExpirationTime = false,
                      ValidateLifetime = true
                  };
              });


            services
                .AddScoped<IJwtProvider, JwtProvider>()
                .AddScoped<RestaurantManagementSystemSeeder>()
                .AddScoped<IDishRepository, DishRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderStatusesRepository, OrderStatusesRepository>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IEmailTemplateGenerator, EmailTemplateGenerator>();



        }
    }
}
