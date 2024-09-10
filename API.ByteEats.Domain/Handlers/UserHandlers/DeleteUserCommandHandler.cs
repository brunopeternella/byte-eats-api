using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.UserCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Domain.Handlers.UserHandlers;

public class DeleteUserCommandHandler : BaseHandler<DeleteUserCommand, Unit>
{
    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var deletedUser = await UnitOfWork.Users.Delete(request.Id);

        if (deletedUser?.State != EntityState.Deleted)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(User),
                request.Id.ToString());
            return Unit.Value;
        }

        await UnitOfWork.SaveAsync();
        return Unit.Value;
    }
}
