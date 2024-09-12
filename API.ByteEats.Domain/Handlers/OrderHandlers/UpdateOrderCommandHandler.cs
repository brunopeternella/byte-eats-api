using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Enums;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.OrderCommands;

namespace API.ByteEats.Domain.Handlers.OrderHandlers;

public class UpdateOrderCommandHandler : BaseHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
{
    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Result<UpdateOrderCommandResponse>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await UnitOfWork.Orders.GetById(request.Id);

        if (order is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Order),
                request.Id.ToString());
            return Result<UpdateOrderCommandResponse>.Failure();
        }

        if (request.WasPaid.HasValue) order.WasPaid = (bool)request.WasPaid;
        if (request.Status.HasValue) order.Status = (OrderStatus)request.Status;

        var updatedOrder = UnitOfWork.Orders.Update(order);

        await UnitOfWork.SaveAsync();

        var response = new UpdateOrderCommandResponse(updatedOrder.Entity);

        return Result<UpdateOrderCommandResponse>.Success(response);
    }
}
