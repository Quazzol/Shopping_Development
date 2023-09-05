using Quadro.Account.Domain.Common;
using System;

namespace Quadro.Account.API
{
    public class ServiceDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceDomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }   
        public void Dispatch<T>(T @event) where T : IDomainEvent
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            var handlers = _serviceProvider.GetServices<IDomainEventHandler<T>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
