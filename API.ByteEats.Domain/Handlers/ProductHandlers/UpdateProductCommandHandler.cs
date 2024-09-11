using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.Notification;
using API.ByteEats.Domain.Models.ProductCommands;

namespace API.ByteEats.Domain.Handlers.ProductHandlers;

public class UpdateProductCommandHandler : BaseHandler<UpdateProductCommand, Product>
{
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Result<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await UnitOfWork.Products.GetById(request.Id);

        if (product is null)
        {
            NotificationService.AddNotification(NotificationMessages.Type.NotFound, nameof(Product),
                request.Id.ToString());
            return Result<Product>.Failure();
        }

        if (request.Name is not null) product.Name = request.Name;
        if (request.Description is not null) product.Description = request.Description;
        if (request.Price is not null) product.Price = (decimal)request.Price;
        if (request.Serves is not null) product.Serves = (int)request.Serves;

        var updatedProduct = UnitOfWork.Products.Update(product);

        await UnitOfWork.SaveAsync();

        var response = updatedProduct.Entity;

        return Result<Product>.Success(response);

    }
}
