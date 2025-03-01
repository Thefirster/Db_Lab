using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.EntityFramework.Mappings;

public class MusiccMap : IEntityTypeConfiguration<Musicc>
{
    public void Configure(EntityTypeBuilder<Musicc> builder)
    {
        builder.HasIndex(p => p.MusicID).IsUnique();
        builder.HasKey(p => p.MusicID);

        builder.HasOne(p => p.album).WithMany(p => p.musics).HasForeignKey(p => p.AlbumID);

        builder.Property(p => p.AlbumID).IsRequired(false);
    }
}
