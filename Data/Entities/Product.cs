using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Abstraction;

namespace Data.Entities;

[Table("Products")]
public record Product(): BaseEntity, IAuditable, IConcurrent
{
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
    public decimal Price { get; set; }
    
    /// <summary>
    /// Product description
    /// </summary>
    public string Description { get; set; } = "";
    
    /// <summary>
    /// Current Stock of the product. In case of reserved products quantity can have negative value
    /// </summary>
    public int Stock { get; init; }
    
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string CreatedBy { get; set; } = "";
    public byte[] RowVersion { get; set; } = [];
}