using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Enums;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.OrderCommands;
using API.ByteEats.Domain.Models.OrderCommands.Responses;
using MediatR;

namespace API.ByteEats.Domain.Handlers.OrderHandlers;

public class CreateOrderCommandHandler : BaseHandler<CreateOrderCommand, OrderResponse>
{
    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Result<OrderResponse>> Handle(CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var orderItems = new List<OrderItem>();
        decimal totalValue = 0;

        var user = await UnitOfWork.Users.GetById(request.UserId);

        if (user is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(User),
                user.Email);
            return Result<OrderResponse>.Failure();
        }

        var order = new Order
        {
            UserId = user.Id,
            WasPaid = true,
            Status = request.Status ?? OrderStatus.New
        };

        await UnitOfWork.Orders.Create(order);

        foreach (var item in request.Items)
        {
            var product = await UnitOfWork.Products.GetById(item.ProductId);

            if (product is null)
            {
                NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Product),
                    item.ProductId.ToString());
                continue;
            }

            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Quantity = item.Quantity
            };

            await UnitOfWork.OrderItems.Create(orderItem);

            orderItems.Add(orderItem);

            totalValue += item.Quantity * product.Price;
        }

        if (NotificationService.HasNotifications())
            return Result<OrderResponse>.Failure();

        await UnitOfWork.SaveAsync();

        var response = new OrderResponse(order, orderItems);

        return Result<OrderResponse>.Success(response);
    }
}
