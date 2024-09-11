using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.OrderCommands;
using API.ByteEats.Domain.Models.OrderCommands.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Domain.Handlers.OrderHandlers;

public class DeleteOrderCommandHandler : BaseHandler<DeleteOrderCommand, OrderResponse>
{
    public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Result<OrderResponse>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await UnitOfWork.Orders.GetById(request.Id);

        if (order is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Order),
                request.Id.ToString());
            return Result<OrderResponse>.Failure();
        }

        var orderItems = await UnitOfWork.OrderItems.GetByOrder(order.Id);

        var response = new OrderResponse(order, orderItems);

        foreach (var item in orderItems)
            UnitOfWork.OrderItems.Delete(item);

        UnitOfWork.Orders.Delete(order);

        await UnitOfWork.SaveAsync();

        return Result<OrderResponse>.Success(response);
    }
}
