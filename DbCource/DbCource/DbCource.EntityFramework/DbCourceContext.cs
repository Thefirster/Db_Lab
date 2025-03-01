using DbCource.EntityFramework.Mappings;
using DbCource.Entity;
using Microsoft.EntityFrameworkCore;

namespace DbCource.EntityFramework;
public class DbCourceContext : DbContext
{
    public DbCourceContext() { }
    public DbCourceContext(DbContextOptions<DbCourceContext> options ): base(options) { }

    public DbSet<Contract>? contracts { get; set; }
    public DbSet<Inbound>? inbounds { get; set; }
    public DbSet<Product>? products { get; set; }
    public DbSet<Supplier>? suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(
                    Environment.CurrentDirectory, "DbCourceContext.db");
        Console.WriteLine($"Using {path} database file.");

        optionsBuilder.UseSqlite($"Filename={path}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContractMap());
        modelBuilder.ApplyConfiguration(new InboundMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new SupplierMap());
        modelBuilder.ApplyConfiguration(new ProductForWarehourceMap());
        modelBuilder.ApplyConfiguration(new OutboundMap());
    }
}
