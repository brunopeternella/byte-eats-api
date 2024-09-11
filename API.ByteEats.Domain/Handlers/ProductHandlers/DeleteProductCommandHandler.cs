using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.ProductCommands;
using Microsoft.EntityFrameworkCore;

namespace API.ByteEats.Domain.Handlers.ProductHandlers;

public class DeleteProductCommandHandler : BaseHandler<DeleteProductCommand, Product>
{
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Result<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var deletedProduct = (await UnitOfWork.Products.Delete(request.Id))?.Entity;

        if (deletedProduct is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Product),
                request.Id.ToString());
            return Result<Product>.Failure();
        }

        await UnitOfWork.SaveAsync();

        return Result<Product>.Success(deletedProduct);

    }
}
