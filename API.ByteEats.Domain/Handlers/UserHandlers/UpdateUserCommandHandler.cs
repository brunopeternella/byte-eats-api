using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.UserCommands;

namespace API.ByteEats.Domain.Handlers.UserHandlers;

public class UpdateUserCommandHandler : BaseHandler<UpdateUserCommand, User>
{
    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.Users.GetById(request.Id);

        if (user is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(User),
                request.Id.ToString());
            return null;
        }

        if (request.Name is not null) user.Name = request.Name;

        var updatedUser = UnitOfWork.Users.Update(user);

        await UnitOfWork.SaveAsync();

        return updatedUser.Entity;
    }
}
