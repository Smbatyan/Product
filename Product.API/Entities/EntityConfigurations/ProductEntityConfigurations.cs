using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.API.Entities.EntityConfigurations;

public class ProductEntityConfigurations : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=> x.Name).HasMaxLength(100);
        builder.Property(x=> x.Description).HasMaxLength(500);
    }
}