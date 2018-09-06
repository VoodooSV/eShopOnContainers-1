using Autofac;
using MediatR;
using Ordering.API.Application.DomainEventHandlers.OrderStartedEvent;
using Ordering.API.Infrastructure.Behaviors;
using Ordering.API.Application.Commands;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
            
            // Register all the Command classes (they implement AsyncRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CancelOrderCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(AsyncRequestHandler<>));

            // Register all the event classes (they implement AsyncNotificationHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));
            
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
