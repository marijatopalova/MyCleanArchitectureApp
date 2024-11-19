using MediatR;
using MyCleanArchitectureApp.Application.Products.DTOs;
using MyCleanArchitectureApp.Domain.Interfaces;

namespace MyCleanArchitectureApp.Application.Products.Queries
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository) 
        : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception($"Product with ID {request.Id} not found.");
            }

            return new ProductDto(product.Id, product.Name, product.Price);
        }
    }
}
