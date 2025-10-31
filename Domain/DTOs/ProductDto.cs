namespace Domain.DTOs;

public record ProductDto
{
    public required Guid Id { get; set; }
    
    /// <summary>
    /// Name of the products
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Uri to product image
    /// </summary>
    public required Uri MainImage { get; set; }
    
    /// <summary>
    /// Price of the product
    /// </summary>
    public decimal? Price { get; set; }
    
    /// <summary>
    /// Product description
    /// </summary>
    public string? Description { get; set; } = "";
    
    /// <summary>
    /// Current Stock of the product. In case of reserved products quantity can have negative value
    /// </summary>
    public int? Stock { get; init; }
}