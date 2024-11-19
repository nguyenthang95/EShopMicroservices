namespace Ordering.API.Endpoints;

public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);
public class GetOrderByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
        {
            var result = await sender.Send(new GetOrderByNameQuery(orderName));

            var response = result.Adapt<GetOrderByNameResponse>();

            return Results.Ok(response);
        }).WithName("GetOrderByName")
        .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Order By Name")
        .WithDescription("Get Order By Name");
    }
}
