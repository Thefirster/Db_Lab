using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DbCource.EntityFramework.Mappings;

public class ContractMap : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasIndex(p => p.ContractID).IsUnique();
        builder.HasKey(p => p.ContractID);

        builder.HasOne(p => p.Inbound).WithOne(p => p.Contracts);
        builder.HasOne(p => p.Supplier).WithMany(p => p.Contracts).HasForeignKey(p => p.SupplierID);
        builder.HasOne(p => p.Product).WithMany(p => p.Contracts).HasForeignKey(p => p.ProductID);

        builder.Property(p => p.InboundID).IsRequired(false);
        builder.Property(p => p.SupplierID).IsRequired(false);
        builder.Property(p => p.ProductID).IsRequired(false);
    }
}