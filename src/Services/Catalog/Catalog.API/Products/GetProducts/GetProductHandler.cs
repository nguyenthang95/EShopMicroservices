

namespace Catalog.API.Products.GetProducts;

public record GetProductQuery(int? PageNumber = 1, int? PageSize = 10, string SearchText = "") : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var queryProduct = session.Query<Product>();

        if (!query.SearchText.IsEmpty())
            queryProduct = (Marten.Linq.IMartenQueryable<Product>)queryProduct.Where(x => x.Name.Contains(query.SearchText));

        var products = await queryProduct
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetProductResult(products);
    }
}
