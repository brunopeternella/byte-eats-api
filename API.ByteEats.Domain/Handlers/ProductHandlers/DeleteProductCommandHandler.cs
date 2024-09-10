using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
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

    public override async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var deletedProduct = await UnitOfWork.Products.Delete(request.Id);

        if (deletedProduct?.State != EntityState.Deleted)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Product),
                request.Id.ToString());
            return null;
        }

        await UnitOfWork.SaveAsync();

        return null;
    }
}
