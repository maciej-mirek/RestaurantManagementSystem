
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Application.Common.Extensions;
using RestaurantManagementSystem.Infrastructure.Extensions;
using RestaurantManagementSystem.Infrastructure.Seeders;
using RestaurantManagementSystem.WebAPI.Middleware;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

namespace RestaurantManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructure(builder);
            builder.Services.AddApplication();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<ExceptionsMiddleware>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

           

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();

            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseSerilogRequestLogging();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                var scope = app.Services.CreateScope();
                var seeder = scope.ServiceProvider.GetRequiredService<RestaurantManagementSystemSeeder>();
                await seeder.Seed();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}