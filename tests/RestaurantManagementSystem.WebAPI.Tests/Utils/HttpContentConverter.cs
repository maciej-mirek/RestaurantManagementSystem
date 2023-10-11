using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.WebAPI.Tests.Utils
{
    public static class HttpContentConverter
    {
        public static HttpContent ConvertObjectToJsonHttpContent(this object obj)
        {
            var objJson = JsonConvert.SerializeObject(obj);

            return new StringContent(objJson, Encoding.UTF8, "application/json");
        }
    }
}
