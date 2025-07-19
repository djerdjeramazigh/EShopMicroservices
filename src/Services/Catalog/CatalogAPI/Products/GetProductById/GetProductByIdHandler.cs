
namespace CatalogAPI.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler(IDocumentSession session,ILogger<GetProductByIdQueryHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling GetProductByIdQuery. Handle called with {@Query}", query);
            // Simulate fetching a product by ID from a database or service
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            if (product == null)
            {
                logger.LogWarning("Product with ID {Id} not found", query.Id);
                throw new ProductNotFoundException();
            }
            return new GetProductByIdResult(product);
        }
    }
}
