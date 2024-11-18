
namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand() : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult();

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommandHandler>
{
    public CheckoutBasketCommandValidator()
    {
        
    }
}

public class CheckoutBasketCommandHandler : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
    {


        return new CheckoutBasketResult();
    }
}
