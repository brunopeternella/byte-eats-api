using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.OrderCommands;
using API.ByteEats.Domain.Models.OrderCommands.Responses;

namespace API.ByteEats.Domain.Handlers.OrderHandlers;

public class GetOrderByIdQueryHandler : BaseHandler<GetOrderByIdQuery, OrderResponse>
{
    public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Result<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await UnitOfWork.Orders.GetByIdAsNoTracking(request.Id);

        if (order is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Order),
                request.Id.ToString());
            return Result<OrderResponse>.Failure();
        }

        var orderItems =  await UnitOfWork.OrderItems.GetByOrderAsNoTracking(order.Id);

        var response = new OrderResponse(order, orderItems);

        return Result<OrderResponse>.Success(response);
    }
}
