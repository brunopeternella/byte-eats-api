using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.UserCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Domain.Handlers.UserHandlers;

public class DeleteUserCommandHandler : BaseHandler<DeleteUserCommand, User>
{
    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<Result<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var deletedUser = (await UnitOfWork.Users.Delete(request.Id))?.Entity;

        if (deletedUser is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(User),
                request.Id.ToString());
            return Result<User>.Failure();
        }

        await UnitOfWork.SaveAsync();

        return Result<User>.Success(deletedUser);
    }
}
