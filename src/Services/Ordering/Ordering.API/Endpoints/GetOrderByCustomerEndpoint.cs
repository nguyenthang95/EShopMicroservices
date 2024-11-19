namespace Ordering.API.Endpoints;

public record GetOrderByCustomerResponse(IEnumerable<OrderDto> Orders);
public class GetOrderByCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrderByCustomerQuery(customerId));

            var response = result.Adapt<GetOrderByCustomerResponse>();

            return Results.Ok(response);
        }).WithName("GetOrderByCustomer")
        .Produces<GetOrderByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Order By Customer")
        .WithDescription("Get Order By Customer");
    }
}
