namespace Ordering.API.Endpoints;

public record GetOrdersResponse(PaginatedResult<OrderDto> Paginated);

public class GetOrdersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet( "/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetOrdersQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetOrdersResponse>();

            return Results.Ok(response);
        }).WithName("GetOrders")
        .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Order")
        .WithDescription("Get Order");
    }
}
