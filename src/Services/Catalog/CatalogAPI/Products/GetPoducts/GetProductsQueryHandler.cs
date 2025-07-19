namespace CatalogAPI.Products.GetPoducts
{
    public record GetProductsQuery:IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger):IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductsQuery. Handle called with {@Query}", query);
            // Simulate fetching products from a database or service
            var products = await session.Query<Product>()
                .ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }

    }
}
