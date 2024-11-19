using Microsoft.EntityFrameworkCore;
using MyCleanArchitectureApp.Domain.Entities;
using MyCleanArchitectureApp.Domain.Interfaces;
using MyCleanArchitectureApp.Infrastructure.Data;

namespace MyCleanArchitectureApp.Infrastructure.Repositories
{
    public class ProductsRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task AddAsync(Product product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product != null) 
            { 
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
