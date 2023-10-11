using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Services.Email
{
    public class EmailTemplateGenerator : IEmailTemplateGenerator
    {
        public string OrderConfirmationEmail(Order order)
        {
            StringBuilder content = new StringBuilder();

            content.AppendLine("Content emaila");

            return content.ToString();
        }
    }
}
