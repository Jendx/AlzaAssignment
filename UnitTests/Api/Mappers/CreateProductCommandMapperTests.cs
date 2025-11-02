using Api.Commands;
using Api.Mappers;
using Shouldly;
using UnitTests.Constants;

namespace UnitTests.Api.Mappers;

[TestFixture(Category = TestCategories.MAPPERS)]
public class CreateProductCommandMapperTests
{
    [Test]
    public void ToProductDto_MapsAllPropertiesCorrectly()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            ProductName = "Keyboard",
            ProductImage = new Uri("https://example.com/keyboard.png"),
            Price = 99.99m,
            Description = "Mechanical keyboard",
            Stock = 12
        };

        // Act
        var dto = ProductCommandMapper.ToProductDto(command);

        // Assert
        dto.Name.ShouldBe(command.ProductName);
        dto.MainImage.ShouldBe(command.ProductImage);
        dto.Price.ShouldBe(command.Price);
        dto.Stock.ShouldBe(command.Stock);
        dto.Description.ShouldBe(command.Description);
    }
    
    [Test]
    public void ToProductDto_ObjectIsNull_Throws()
    {
        // Arrange
        var command = (CreateProductCommand) null;

        // Act
        var mappAction = () => ProductCommandMapper.ToProductDto(command);

        // Assert
        mappAction.ShouldThrow<ArgumentNullException>();
    }
}