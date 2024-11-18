
using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketRequest();
public record CheckoutBasketResponse();

public class CheckoutBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender)=>
        {
            var command = request.Adapt<CheckoutBasketCommand>();

            var result = sender.Send(command);

            var response = result.Adapt<CheckoutBasketResponse>();

            return Results.Ok();
        }).WithName("CheckoutBasket")
        .Produces<CheckoutBasketResponse>(StatusCodes.Status200OK)
        .WithSummary("Checkout Basket")
        .WithDescription("Checkout Basket");
    }
}
