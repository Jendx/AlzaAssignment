using Data.Entities;
using Data.Mappers;
using Domain.DTOs;
using Shouldly;
using UnitTests.Constants;

namespace UnitTests.Data.Mappers;

[TestFixture(Category = TestCategories.MAPPERS)]
public class ProductMapperTests
{
    [Test]
    public void ToProductDto_ShouldMapAllProperties_Correctly()
    {
        // Arrange
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Wireless Mouse",
            Description = "Ergonomic design",
            Price = 29.99m,
            MainImage = new Uri("https://example.com/mouse.png"),
            Stock = 10
        };

        // Act
        var dto = ProductMapper.ToProductDto(product);

        // Assert
        dto.Id.ShouldBe(product.Id);
        dto.Name.ShouldBe(product.Name);
        dto.Description.ShouldBe(product.Description);
        dto.Price.ShouldBe(product.Price);
        dto.MainImage.ShouldBe(product.MainImage);
        dto.Stock.ShouldBe(product.Stock);
    }

    [Test]
    public void ToProductDto_ShouldThrowWhenNull()
    {
        // Arrange
        Product? product = null;

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => ProductMapper.ToProductDto(product!));
    }

    [Test]
    public void ToProduct_ShouldMapAllProperties_Correctly()
    {
        // Arrange
        var dto = new ProductDto
        {
            Id = Guid.NewGuid(),
            Name = "Mechanical Keyboard",
            Description = "RGB Backlit",
            Price = 99.50m,
            MainImage = new Uri("https://example.com/keyboard.png"),
            Stock = 25
        };

        // Act
        var product = ProductMapper.ToProduct(dto);

        // Assert
        product.Id.ShouldBe(dto.Id);
        product.Name.ShouldBe(dto.Name);
        product.Description.ShouldBe(dto.Description);
        product.Price.ShouldBe(dto.Price);
        product.MainImage.ShouldBe(dto.MainImage);
        product.Stock.ShouldBe(dto.Stock);
    }

    [Test]
    public void ToProduct_ShouldThrowWhenNull()
    {
        // Arrange
        ProductDto? dto = null;

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => ProductMapper.ToProduct(dto!));
    }

    [Test]
    public void Mapper_ShouldPreserveValuesWhenRoundTrip()
    {
        // Arrange
        var original = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Gaming Headset",
            Description = "Noise-cancelling",
            Price = 79.99m,
            MainImage = new Uri("https://example.com/headset.png"),
            Stock = 5
        };

        // Act
        var dto = ProductMapper.ToProductDto(original);
        var mappedBack = ProductMapper.ToProduct(dto);

        // Assert
        mappedBack.Id.ShouldBe(original.Id);
        mappedBack.Name.ShouldBe(original.Name);
        mappedBack.Description.ShouldBe(original.Description);
        mappedBack.Price.ShouldBe(original.Price);
        mappedBack.MainImage.ShouldBe(original.MainImage);
        mappedBack.Stock.ShouldBe(original.Stock);
    }
}