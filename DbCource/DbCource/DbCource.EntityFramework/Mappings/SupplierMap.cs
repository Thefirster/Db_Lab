using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCource.EntityFramework.Mappings;

public class SupplierMap : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasIndex(s => s.SupplierID).IsUnique(); //主键
        builder.HasKey(s => s.SupplierID);
    }
}