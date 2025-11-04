using System.ComponentModel.DataAnnotations;
using Domain.Constants;

namespace Api.Commands;

internal sealed record CreateProductCommand
{
    [Required]
    [MinLength(1)]
    [MaxLength(Constraints.PRODUCT_NAME_MAX_LENGTH)]
    public required string ProductName { get; init; }
    
    [Required] 
    [Url]
    public required Uri ProductImage { get; init; }
    public decimal? Price { get; init; }
    
    [MaxLength(Constraints.PRODUCT_DESCRIPTION_MAX_LENGTH)]
    public string? Description { get; init; }
    
    /// <summary>
    /// Current Stock of the product. In case of reserved products quantity can have negative value
    /// </summary>
    public int? Stock { get; init; }
}