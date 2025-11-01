using Api.Commands;
using Domain.DTOs;

namespace Api.Mappers;

internal static class ProductCommandMapper
{
    public static ProductDto ToProductDto(CreateProductCommand createCommand)
    {
        ArgumentNullException.ThrowIfNull(createCommand);
        
        return new ProductDto()
        {
            Id = Guid.NewGuid(),
            MainImage = createCommand.ProductImage,
            Name = createCommand.ProductName,
            Price = createCommand.Price,
            Description = createCommand.Description,
            Stock = createCommand.Stock,
        };
    }
}