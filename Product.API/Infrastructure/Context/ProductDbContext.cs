using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Entities.EntityConfigurations;

namespace Product.API.Infrastructure.Context;

public class ProductDbContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }

    public ProductDbContext() : base()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityConfigurations());
    }
}