using Data.Entities.Abstraction;
using Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Helpers;

internal static class AuditHelper
{
    /// <summary>
    /// Handles Add & update auditing properties
    /// </summary>
    /// <param name="changeTracker"></param>
    public static void UpdateAuditFields(ChangeTracker changeTracker)
    {
        var entries = changeTracker.Entries<IAuditable>();

        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;
            var user = Users.SYSTEM; // TODO: replace with current user

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = now;
                entry.Entity.ModifiedOn = now;
                entry.Entity.CreatedBy = user;
                continue;
            }
            
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedOn = now;
            }
        }
    }
}