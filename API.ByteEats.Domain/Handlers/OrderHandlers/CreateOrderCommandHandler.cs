using API.ByteEats.Domain.DTOs;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.OrderCommands;

namespace API.ByteEats.Domain.Handlers.OrderHandlers;

public class CreateOrderCommandHandler : BaseHandler<CreateOrderCommand, CreateOrderCommandResponse>
{
    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.Users.GetById(request.UserId);
        var orderItemsResponse = new List<OrderItemResponseDTO>();
        decimal totalValue = 0;

        var order = new Order
        {
            UserId = user.Id,
            WasPaid = true
        };

        await UnitOfWork.Orders.Create(order);

        foreach (var item in request.Items)
        {
            var product = await UnitOfWork.Products.GetById(item.ProductId);

            if (product is null)
            {
                NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Product),
                    item.ProductId.ToString());
            }
            else
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = item.Quantity
                };

                await UnitOfWork.OrderItems.Create(orderItem);

                orderItemsResponse.Add(new OrderItemResponseDTO
                {
                    Id = orderItem.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitValue = product.Price,
                    Quantity = item.Quantity
                });

                totalValue += item.Quantity * product.Price;
            }
        }

        if (NotificationService.HasNotifications())
            return null;

        var response = new CreateOrderCommandResponse
        {
            Id = order.Id,
            UserEmail = user.Email,
            UserName = user.Name,
            WasPaid = order.WasPaid,
            TotalValue = totalValue,
            Items = orderItemsResponse
        };

        await UnitOfWork.SaveAsync();

        return response;
    }
}
