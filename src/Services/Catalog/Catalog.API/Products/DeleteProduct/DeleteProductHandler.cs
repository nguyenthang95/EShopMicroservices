using Catalog.API.Products.GetProductById;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductQuery(Guid Id) : IQuery<DeleteProductResult>;

public record DeleteProductResult(bool IsDeleted);

public class DeleteProductQueryHandler(IDocumentSession session, ILogger<DeleteProductQueryHandler> logger) : IQueryHandler<DeleteProductQuery, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductQueryHandler.Handler call with @{query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException();
        }

        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
