using System.Linq.Expressions;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.ProductCommands;

namespace API.ByteEats.Domain.Handlers.ProductHandlers;

public class GetProductsQueryHandler : BaseHandler<GetProductsQuery, PagedResult<Product>>
{
    public GetProductsQueryHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<PagedResult<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        List<Expression<Func<Product, bool>>> filters = new();

        if (request.Category.HasValue)
            filters.Add(product => product.Category.Equals(request.Category));

        if(request.Promotion.HasValue)
            filters.Add(product => product.Promotion.Equals(request.Promotion));

        var products = await UnitOfWork.Products.GetAll(request.Page, request.PageSize, filters);

        return products;
    }
}
