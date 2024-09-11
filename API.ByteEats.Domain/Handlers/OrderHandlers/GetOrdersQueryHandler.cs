using System.Linq.Expressions;
using API.ByteEats.Domain.Entities;
using API.ByteEats.Domain.Interfaces;
using API.ByteEats.Domain.Interfaces.Repositories.Base;
using API.ByteEats.Domain.Models;
using API.ByteEats.Domain.Models.OrderCommands;
using API.ByteEats.Domain.Models.OrderCommands.Responses;

namespace API.ByteEats.Domain.Handlers.OrderHandlers;

public class GetOrdersQueryHandler : BaseHandler<GetOrdersQuery, PagedResult<OrderResponse>>
{
    public GetOrdersQueryHandler(IUnitOfWork unitOfWork, INotificationService notificationService) : base(unitOfWork,
        notificationService)
    {
    }

    public override async Task<Result<PagedResult<OrderResponse>>> Handle(GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        List<Expression<Func<Order, bool>>> filters = new();
/*
        if (request.Category.HasValue)
            filters.Add(product => product.Category.Equals(request.Category));

        if(request.Promotion.HasValue)
            filters.Add(product => product.Promotion.Equals(request.Promotion));
*/
        var pagedOrders = await UnitOfWork.Orders.GetPagedByFilter(request.Page, request.PageSize);

        var ordersResponse = new List<OrderResponse>();

        foreach (var order in pagedOrders.Items)
        {
            var orderItems =  await UnitOfWork.OrderItems.GetByOrderAsNoTracking(order.Id);
            ordersResponse.Add(new OrderResponse(order, orderItems));
        }

        var response = new PagedResult<OrderResponse>(ordersResponse, pagedOrders.TotalCount,
            pagedOrders.Page, pagedOrders.PageSize);

        return Result<PagedResult<OrderResponse>>.Success(response);;
    }
}
