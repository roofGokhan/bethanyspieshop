using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models;

public class BethanysPieShopDbContext : DbContext
{
    public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : base(options)
    {
    }

    public DbSet<Pie> Pies { get; set; }
    public DbSet<Category?> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BethanysPieShopDbContext)
            .Assembly); // Apply all configurations in the assembly

        modelBuilder.Entity<Pie>().ToTable("Pies");
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

        //configuring using Fluent API
        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .IsRequired();
    }
}