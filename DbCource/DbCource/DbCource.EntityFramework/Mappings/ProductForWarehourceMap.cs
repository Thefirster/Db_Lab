using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DbCource.EntityFramework.Mappings;

public class ProductForWarehourceMap : IEntityTypeConfiguration<ProductForWarehource>
{
    public void Configure(EntityTypeBuilder<ProductForWarehource> builder)
    {
        builder.HasIndex(p => p.ProductID).IsUnique();
        builder.HasKey(p => p.ProductID);
    }
}