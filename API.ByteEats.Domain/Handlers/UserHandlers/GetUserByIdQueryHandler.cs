using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.UserCommands;

namespace API.ByteEats.Domain.Handlers.UserHandlers;

public class GetUserByIdQueryHandler : BaseHandler<GetUserByIdQuery, User>
{
    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.Users.GetById(request.Id);

        if (user is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(User),
                request.Id.ToString());
            return Result<User>.Failure();

        }

        return Result<User>.Success(user);
    }
}
