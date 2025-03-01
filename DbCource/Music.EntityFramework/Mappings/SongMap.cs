using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Mappings;

public class SongMap : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasIndex(p => p.SongID).IsUnique();
        builder.HasKey(p => p.SongID);

        builder.HasOne(p => p.music).WithOne(p => p.song).HasForeignKey<Song>(e => e.MusicID);
        builder.HasOne(p => p.songTable).WithMany(p => p.songs).HasForeignKey(p => p.SongTableID);

        builder.Property(p => p.SongTableID).IsRequired(false);
        builder.Property(p => p.MusicID).IsRequired(false);

    }
}
