using Domain.DTOs;

namespace Domain.Providers;

public interface IProductService
{
    Task<ProductDto> GetProductAsync(Guid id);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<List<ProductDto>> GetProductsAsync(int skip, int take);
    Task<ProductDto> UpdateProductStockAsync(Guid id, int newStock);
    Task<ProductDto> CreateProductAsync(ProductDto newProduct);
}