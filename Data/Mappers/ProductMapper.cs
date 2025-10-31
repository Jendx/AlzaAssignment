using Data.Entities;
using Domain.DTOs;

namespace Data.Mappers;

public static class ProductMapper
{
    public static ProductDto ToProductDto(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            MainImage = product.MainImage,
            Stock = product.Stock,
        };
    }

    public static Product ToProduct(ProductDto productDto)
    {
        ArgumentNullException.ThrowIfNull(productDto);

        return new Product()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            MainImage = productDto.MainImage,
            Stock = productDto.Stock,
        };
    }
}