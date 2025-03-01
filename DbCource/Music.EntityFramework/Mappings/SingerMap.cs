using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Mappings;

public class SingerMap : IEntityTypeConfiguration<Singer>
{
    public void Configure(EntityTypeBuilder<Singer> builder)
    {
        builder.HasIndex(p => p.SingerID).IsUnique();
        builder.HasKey(p => p.SingerID);
    }
}
