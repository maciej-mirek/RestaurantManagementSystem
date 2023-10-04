using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Application.Dishes.Commands.ChangeDishVisibility;
using RestaurantManagementSystem.Application.Dishes.Commands.CreateDish;
using RestaurantManagementSystem.Application.Mappings;
using RestaurantManagementSystem.Application.Orders.Commands.CreateOrder;

namespace RestaurantManagementSystem.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssemblies(assembly));

            services
                .AddValidatorsFromAssemblyContaining<CreateDishCommandValidator>()
               .AddFluentValidationAutoValidation()
               .AddFluentValidationClientsideAdapters();

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            cfg.AddProfile(new MappingProfile())).CreateMapper());
        }
    }
}
