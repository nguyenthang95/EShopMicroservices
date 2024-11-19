namespace Ordering.API.Endpoints;

public record CreateOrderRequest(OrderDto OrderDto);
public record CreateOrderResponse(Guid Id);

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateOrderCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/products/{response.Id}", response);
        }).WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}
