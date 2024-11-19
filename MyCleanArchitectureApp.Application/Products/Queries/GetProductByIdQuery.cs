using MediatR;
using MyCleanArchitectureApp.Application.Products.DTOs;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}
