using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities.Abstraction;

[PrimaryKey(nameof(Id))]
public abstract record BaseEntity
{
    public required Guid Id { get; set; }
}
