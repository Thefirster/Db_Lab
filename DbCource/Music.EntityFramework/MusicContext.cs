using Music.Contracts;
using Music.Entity;
using Microsoft.EntityFrameworkCore;
using Music.EntityFramework.Mappings;
using System.Diagnostics.Contracts;

namespace Music.EntityFramework;
public class MusicContext : DbContext
{
    public MusicContext() { }
    public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }

    public DbSet<Album>? albums { get; set; }
    public DbSet<Musicc>? musiccs { get; set; }
    public DbSet<User>? users { get; set; }
    public DbSet<Singer>? singers { get; set; }
    public DbSet<SongTable>? songTables { get; set; }
    public DbSet<Song>? songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(
                    Environment.CurrentDirectory, "DbCourceContext.db");
        Console.WriteLine($"Using {path} database file.");

        optionsBuilder.UseSqlite($"Filename={path}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumMap());
        modelBuilder.ApplyConfiguration(new MusiccMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new SingerMap());
        modelBuilder.ApplyConfiguration(new SongMap());
        modelBuilder.ApplyConfiguration(new SongTableMap());
    }
}
