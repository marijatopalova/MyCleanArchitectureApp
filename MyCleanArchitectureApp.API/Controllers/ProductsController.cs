using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCleanArchitectureApp.Application.Products.Commands;
using MyCleanArchitectureApp.Application.Products.DTOs;
using MyCleanArchitectureApp.Application.Products.Queries;
using MyCleanArchitectureApp.Domain.Entities;

namespace MyCleanArchitectureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender sender) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await sender.Send(query);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Product product)
        {
            var command = new CreateProductCommand(product.Name, product.Price);
            await sender.Send(command);

            return Ok();
        }
    }
}
