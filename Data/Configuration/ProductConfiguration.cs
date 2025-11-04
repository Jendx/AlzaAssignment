using Data.Entities;
using Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(Constraints.PRODUCT_NAME_MAX_LENGTH);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(Constraints.PRODUCT_DESCRIPTION_MAX_LENGTH);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(14, 2)");
        builder.Property(p => p.CreatedOn).IsRequired();
        builder.Property(p => p.ModifiedOn).IsRequired();
        builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(100);
        builder.Property(p => p.RowVersion).IsRowVersion();
    }
}