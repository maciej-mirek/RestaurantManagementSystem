using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Application.Common.Mappings;
using RestaurantManagementSystem.Application.Dishes.Commands.CreateDish;

namespace RestaurantManagementSystem.Application.Common.Extensions
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
