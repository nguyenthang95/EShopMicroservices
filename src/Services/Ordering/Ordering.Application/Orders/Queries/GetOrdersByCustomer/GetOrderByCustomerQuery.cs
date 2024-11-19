namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrderByCustomerQuery(Guid customerId) : IQuery<GetOrderByCustomerResult>;
public record GetOrderByCustomerResult(IEnumerable<OrderDto> Orders);
