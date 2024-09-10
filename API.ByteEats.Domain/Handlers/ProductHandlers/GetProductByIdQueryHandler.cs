using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.ProductCommands;

namespace API.ByteEats.Domain.Handlers.ProductHandlers;

public class GetProductByIdQueryHandler : BaseHandler<GetProductByIdQuery, Product>
{
    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await UnitOfWork.Products.GetById(request.Id);

        if (product is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(product),
                request.Id.ToString());
            return null;
        }

        return product;
    }
}
