using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Application.Users
{
    public class UserRegistrationRequest
    {
     
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}