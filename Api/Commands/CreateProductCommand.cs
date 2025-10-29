using System.ComponentModel.DataAnnotations;

namespace Api.Commands;

internal sealed record CreateProductCommand
{
    [Required]
    [MinLength(1)]
    public required string ProductName { get; init; }
    
    [Required] 
    [Url]
    public required Uri ProductImage { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    
    /// <summary>
    /// Current Stock of the product. In case of reserved products quantity can have negative value
    /// </summary>
    public int Stock { get; init; }
}