using MediatR;

namespace MyCleanArchitectureApp.Application.Products.Commands
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;
}
