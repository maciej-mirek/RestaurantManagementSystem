
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Domain.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string receiverEmail, string subject, string body);
    }
}
