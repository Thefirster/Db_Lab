using Music.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Contracts;

namespace Music.EntityFramework.Mappings;
public class AlbumMap : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasIndex(p => p.AlbumID).IsUnique();
        builder.HasKey(p => p.AlbumID);

        builder.HasOne(p => p.singer).WithMany(p => p.albums).HasForeignKey(p => p.SingerID);

        builder.Property(p => p.SingerID).IsRequired(false);
    }
}
