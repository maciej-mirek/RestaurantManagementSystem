using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using RestaurantManagementSystem.Domain.Interfaces;


namespace RestaurantManagementSystem.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _host;
        private readonly string? _sender;
        private readonly int? _port;
        public EmailService(IConfiguration configuration)
        {

            _configuration = configuration;
            _host = _configuration?.GetSection("EmailConfig:Host").Value;
            _sender = _configuration?.GetSection("EmailConfig:Sender").Value;
            _port = Convert.ToInt32(_configuration?.GetSection("EmailConfig:Port").Value);
        }
        public void SendEmail(string receiverEmail, string subject, string body)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_sender));
            email.To.Add(MailboxAddress.Parse(receiverEmail));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_host, (int)_port, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_sender, _configuration?.GetSection("EmailConfig:Password").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
