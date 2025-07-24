
namespace CatalogAPI.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    internal class GetProductByCategoryQueryHandler(IDocumentSession session)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            // Simulate fetching products by category from a database or service
            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains( query.Category))
                .ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(products);
        }
    }
    
}
