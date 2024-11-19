using MediatR;
using MyCleanArchitectureApp.Domain.Entities;
using MyCleanArchitectureApp.Domain.Interfaces;

namespace MyCleanArchitectureApp.Application.Products.Commands
{
    public class CreateProductCommandHandler(IProductRepository productRepository) 
        : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
