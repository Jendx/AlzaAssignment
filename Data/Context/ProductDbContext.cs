using Data.Configuration;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ProductDbContext(DbContextOptions options) : BaseDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products => Set<Product>();
}