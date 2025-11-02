using System.ComponentModel.DataAnnotations;

namespace Api.Commands;

internal sealed record UpdateProductStockCommand
{
    [Required]
    public Guid Id { get; init; }
    
    [Required]
    public int NewStock { get; init; }
}