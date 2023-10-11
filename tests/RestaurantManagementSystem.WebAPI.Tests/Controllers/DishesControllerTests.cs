using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestaurantManagementSystem.Application.Dishes;
using RestaurantManagementSystem.Application.Dishes.Commands.ArchiveDish;
using RestaurantManagementSystem.Application.Dishes.Commands.ChangeDishVisibility;
using RestaurantManagementSystem.Application.Users;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.DatabaseContext;
using RestaurantManagementSystem.WebAPI.Tests.Utils;
using System.Net;
using System.Text;
using System.Text.Json;

namespace RestaurantManagementSystem.WebAPI.Tests.Controllers
{
    public class DishesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _http;
        private WebApplicationFactory<Program> _applicationFactory;

        public DishesControllerTests(WebApplicationFactory<Program> factory)
        {
            _applicationFactory = factory
               .WithWebHostBuilder(builder =>
               {
                   builder.ConfigureServices(services =>
                   {
                       var db = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                       services.Remove(db);

                       services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("SqlServerDbInMemory"));

                   });
               });
            _http = _applicationFactory.CreateClient();

        }


        [Fact]
        public async Task GetDishesTest()
        {
            var response = await _http.GetAsync("api/Dishes");
            response.Content.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateDishWithValidModelTest()
        {
            var dish = new DishDto
            {
                Name = "French fries",
                IsVisible = true,
                EstimatedTime = 3,
                Price = 8
            };

            var httpContent = dish.ConvertObjectToJsonHttpContent();

            var response = await _http.PostAsync("api/Dishes", httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateDishWithInvalidModel()
        {
            var dish = new DishDto
            {
                IsVisible = false,
            };

            var httpContent = dish.ConvertObjectToJsonHttpContent();
            var response = await _http.PostAsync("api/Dishes", httpContent);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task ArchiveDishTest()
        {
            var dishId = new ArchiveDishCommand { DishId = 1 }.ConvertObjectToJsonHttpContent();
            var response = await _http.PatchAsync("api/Dishes/Archive", dishId);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ArchiveNonExistingDishTest()
        {
            var dishId = new ArchiveDishCommand { DishId = 9999 }.ConvertObjectToJsonHttpContent();
            var response = await _http.PatchAsync("api/Dishes/Archive", dishId);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Fact]
        public async Task ChangeVisibilityDishTest()
        {

            var changeDishVisibilityCommand = new ChangeDishVisibilityCommand() { DishId = 1, Visibility = true }
                .ConvertObjectToJsonHttpContent();
            var response = await _http.PatchAsync("api/Dishes/ChangeVisibility", changeDishVisibilityCommand);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ChangeVisibilityNonExistingDishTest()
        {
            var changeDishVisibilityCommand = new ChangeDishVisibilityCommand() { DishId = 9999, Visibility = true}
                .ConvertObjectToJsonHttpContent();
            var response = await _http.PatchAsync("api/Dishes/ChangeVisibility",changeDishVisibilityCommand);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
