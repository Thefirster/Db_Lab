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

public class SongTableMap : IEntityTypeConfiguration<SongTable>
{
    public void Configure(EntityTypeBuilder<SongTable> builder)
    {
        builder.HasIndex(p => p.SongTableID).IsUnique();
        builder.HasKey(p => p.SongTableID);

        builder.HasOne(p => p.user).WithMany(p => p.songTables).HasForeignKey(p => p.UserID);

        builder.Property(p => p.UserID).IsRequired(false);
    }
}
