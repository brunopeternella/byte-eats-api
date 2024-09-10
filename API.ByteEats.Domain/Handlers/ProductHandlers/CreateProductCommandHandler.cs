using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models.ProductCommands;

namespace API.ByteEats.Domain.Handlers.ProductHandlers;

public class CreateProductCommandHandler : BaseHandler<CreateProductCommand, Product>
{
    public CreateProductCommandHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(
        unitOfWork, notificationService)
    {
    }

    public override async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Serves = request.Serves
        };

        var result = await UnitOfWork.Products.Create(product);

        var addedProduct = result.Entity;

        await UnitOfWork.SaveAsync();

        return addedProduct;
    }
}
