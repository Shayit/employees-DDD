using MediatR;

namespace Application
{
    public class DomainEventPublisher : IPublisher
    {
        private readonly IMediator _mediator;

        public DomainEventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            return _mediator.Publish(notification, cancellationToken);
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            if (notification is INotification n)
            {
                return _mediator.Publish(n, cancellationToken);
            }

            throw new ArgumentException("Notification must implement INotification", nameof(notification));
        }
    }
}
