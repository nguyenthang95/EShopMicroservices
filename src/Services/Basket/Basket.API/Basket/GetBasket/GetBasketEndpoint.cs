﻿namespace Basket.API.Basket.GetBasket;

public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{UserName}", async (string UserName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(UserName));

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        }).WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .WithSummary("Get Basket")
        .WithDescription("Get Basket"); ;
    }
}