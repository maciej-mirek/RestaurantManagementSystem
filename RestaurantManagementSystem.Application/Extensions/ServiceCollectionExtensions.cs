using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssemblies(assembly));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            cfg.AddProfile(new MappingProfile())).CreateMapper());
        }
    }
}
