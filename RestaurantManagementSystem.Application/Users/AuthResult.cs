using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Users
{
    public class AuthResult
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }
    }
}
