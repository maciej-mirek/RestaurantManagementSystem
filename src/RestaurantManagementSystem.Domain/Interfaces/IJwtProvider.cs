using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Interfaces
{
    public interface IJwtProvider
    {
        Task<string> GenerateJwtToken(IdentityUser<int> user);
    }
}
