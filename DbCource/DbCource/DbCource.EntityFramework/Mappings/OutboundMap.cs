using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCource.Entity;

namespace DbCource.EntityFramework.Mappings;
public class OutboundMap : IEntityTypeConfiguration<Outbound>
{
    public void Configure(EntityTypeBuilder<Outbound> builder)
    {
        builder.HasIndex(p => p.OutboundID).IsUnique();
        builder.HasKey(p => p.OutboundID);
    }
}