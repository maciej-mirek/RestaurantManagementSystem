using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Application.Users;
using RestaurantManagementSystem.Infrastructure.DatabaseContext;
using RestaurantManagementSystem.WebAPI.Tests.Utils;
using System.Net;
using Xunit.Abstractions;

namespace RestaurantManagementSystem.WebAPI.Tests.Controllers
{
    public class AuthenticationControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> _applicationFactory;
        private HttpClient _http;
        public AuthenticationControllerTests(WebApplicationFactory<Program> factory)
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
        public async Task RegisterUserWithValidModelTest()
        {
            var newUser = new UserRegistrationRequest
            {
                Email = "test43@test.pl",
                Password = "Abcde123!@",
            };

            var userToContentHttp = newUser.ConvertObjectToJsonHttpContent();
            var response = await _http.PostAsync("api/Authentication/Register", userToContentHttp);
            var res = await response.Content.ReadAsStreamAsync();
            var result = await System.Text.Json.JsonSerializer.DeserializeAsync
                <AuthResult>(res);

            result.Result.Should().Be(true);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task RegisterUserWithInvalidModelTest()
        {
            var newUser = new UserRegistrationRequest
            {
                Email = "test43@test.pl",
                Password = "!@",
            };

            var userToContentHttp = newUser.ConvertObjectToJsonHttpContent();
            var response = await _http.PostAsync("api/Authentication/Register", userToContentHttp);
            var res = await response.Content.ReadAsStreamAsync();
            var result = await System.Text.Json.JsonSerializer.DeserializeAsync
                <AuthResult>(res);

            result.Result.Should().Be(false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}