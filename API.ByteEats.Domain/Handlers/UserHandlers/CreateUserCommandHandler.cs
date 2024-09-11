using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.UserCommands;

namespace API.ByteEats.Domain.Handlers.UserHandlers;

public class CreateUserCommandHandler : BaseHandler<CreateUserCommand, User>
{
    public CreateUserCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email
        };

        var result = await UnitOfWork.Users.Create(user);

        var addedUser = result.Entity;

        await UnitOfWork.SaveAsync();

        return Result<User>.Success(addedUser);
    }
}
