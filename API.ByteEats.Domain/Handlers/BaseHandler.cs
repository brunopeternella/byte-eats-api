using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using MediatR;

namespace API.ByteEats.Domain.Handlers;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IBaseRequest<TResponse>
{
    protected readonly INotificationService NotificationService;
    protected readonly IUnitOfWork UnitOfWork;

    protected BaseHandler(IUnitOfWork unitOfWork, INotificationService notificationService)
    {
        UnitOfWork = unitOfWork;
        NotificationService = notificationService;
    }

    public abstract Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}
