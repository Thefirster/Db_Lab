using DbCource.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbCource.EntityFramework.Mappings;

public class InboundMap : IEntityTypeConfiguration<Inbound>
{
    public void Configure(EntityTypeBuilder<Inbound> builder)
    {
        builder.HasIndex(p => p.InboundID).IsUnique();
        builder.HasKey(p => p.InboundID);
    }
}
