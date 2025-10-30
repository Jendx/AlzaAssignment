using Data.Entities.Abstraction;
using Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public abstract class BaseDbContext(DbContextOptions options) : DbContext(options)
{
    public override int SaveChanges()
    {
        AuditHelper.UpdateAuditFields(ChangeTracker);
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AuditHelper.UpdateAuditFields(ChangeTracker);
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IAuditable).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(IAuditable.CreatedBy))
                    .IsRequired()
                    .HasMaxLength(100);
            }
            
            // Concurrency config
            if (typeof(IConcurrent).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(IConcurrent.RowVersion))
                    .IsRowVersion();
            }
        }
    }
}