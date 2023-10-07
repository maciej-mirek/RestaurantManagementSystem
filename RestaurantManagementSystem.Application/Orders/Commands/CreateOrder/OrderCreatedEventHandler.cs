using MediatR;
using RestaurantManagementSystem.Domain.DomainEvents;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Orders.Commands.CreateOrder
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly IOrderStatusesRepository _orderStatusesRepository;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateGenerator _emailTemplateGenerator;
        public OrderCreatedEventHandler(IEmailService emailService, IEmailTemplateGenerator emailTemplateGenerator,
            IOrderStatusesRepository orderStatusesRepository)
        {
            _emailService = emailService;
            _emailTemplateGenerator = emailTemplateGenerator;
            _orderStatusesRepository = orderStatusesRepository;
        }

        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _orderStatusesRepository.ChangeStatus(notification.OrderId, StatusEnum.New, null);

            var body = _emailTemplateGenerator.OrderConfirmationEmail(new Order());
            _emailService.SendEmail("",$"Order {notification.OrderId} confirmation.",body);
        }
    }
}
