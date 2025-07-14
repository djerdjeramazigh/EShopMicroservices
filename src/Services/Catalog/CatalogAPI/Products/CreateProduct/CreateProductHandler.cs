using MediatR;

namespace CatalogAPI.Products.CreateProduct
{
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price):IRequest<CreateProductResult>;
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Here you would typically interact with your database to create the product
        // For this example, we will just return a new Guid as the product Id
        var newProductId = Guid.NewGuid();
        return Task.FromResult(new CreateProductResult(newProductId));
    }
    }
{

}
}
