using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.UserCommands;

namespace API.ByteEats.Domain.Handlers.UserHandlers;

public class GetUserQueryHandler : BaseHandler<GetUsersQuery, PagedResult<User>>
{
    public GetUserQueryHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<Result<PagedResult<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await UnitOfWork.Users.GetPagedByFilter(request.Page, request.PageSize);

        return Result<PagedResult<User>>.Success(users);
    }
}
