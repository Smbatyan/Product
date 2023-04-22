using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Infrastructure.Context;

namespace Product.API.Repositories;

public class ProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductEntity>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<ProductEntity>> GetProductsAsync(int page, int pageSize)
    {
        return await _context.Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    public async Task<ProductEntity> GetProductAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task CreateProductAsync(ProductEntity product)
    {
        await _context.Products.AddAsync(product);
    }

    public void UpdateProduct(ProductEntity product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }

    public async Task DeleteProductAsync(int id)
    {
        ProductEntity product = await GetProductAsync(id);
        _context.Products.Remove(product);
    }
    
    public async Task DeleteProductAsync(ProductEntity product)
    {
        _context.Products.Remove(product);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}   