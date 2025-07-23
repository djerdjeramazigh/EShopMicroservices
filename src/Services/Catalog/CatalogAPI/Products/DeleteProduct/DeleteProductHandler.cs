
namespace CatalogAPI.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
   public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID must not be empty.");
        }
    }
    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
       public Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
           logger.LogInformation("Handling DeleteProductCommand. Handle called with {@Command}", command);
            // Simulate deleting a product by ID from a database or service
          
            session.Delete<Product>(command.Id);
            return session.SaveChangesAsync(cancellationToken)
                .ContinueWith(_ => new DeleteProductResult(true), cancellationToken);
        }
    }
}
