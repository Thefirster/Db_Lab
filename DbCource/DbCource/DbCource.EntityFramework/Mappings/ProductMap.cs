using Microsoft.EntityFrameworkCore;
using DbCource.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCource.EntityFramework.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(p => p.ProductID).IsUnique();
        builder.HasKey(p => p.ProductID);

        builder.HasOne(p => p.Supplier).WithMany(p => p.Products).HasForeignKey(p => p.SupplierID);

        builder.Property(p => p.SupplierID).IsRequired(false);
    }
}