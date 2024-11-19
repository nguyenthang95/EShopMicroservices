
using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

internal class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrderResult>
{
    public async Task<GetOrderResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        {
            var pageSize = query.PaginationRequest.PageSize;
            var pageIndex = query.PaginationRequest.PageIndex;

            var totalCount = await dbContext.OrderItems.CountAsync();
            var orders = await dbContext.Orders
                .Include(x => x.OrderItems)
                .OrderBy(x => x.OrderName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new GetOrderResult(
                new PaginatedResult<OrderDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    data: orders.ToOrderDtoList()
                    )
                );
        }
    }
}
