using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using MediatR;

namespace API.ByteEats.Domain.Handlers;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly INotificationService NotificationService;
    protected readonly IUnitOfWork UnitOfWork;

    protected BaseHandler(IUnitOfWork unitOfWork, INotificationService notificationService)
    {
        UnitOfWork = unitOfWork;
        NotificationService = notificationService;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
