using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;
using Ordering.Domain.Events;

namespace Ordering.API.Application.DomainEventHandlers.OrderStartedEvent
{
    public class SendEmailToCustomerWhenOrderStartedDomainEventHandler
                   //: INotificationHandler<OrderStartedDomainEvent>
    { 
        public SendEmailToCustomerWhenOrderStartedDomainEventHandler()
        {
        
        }

        //protected override async Task Handle(OrderStartedDomainEvent orderNotification, CancellationToken cancellationToken)
        //{
        //    //TBD - Send email logic
        //}
    }
}
