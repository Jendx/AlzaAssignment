using Domain.DTOs;

namespace Domain.Providers;

public interface IProductService
{
    public Task<ProductDto> GetProductAsync(Guid id);
    public Task<List<ProductDto>> GetAllProductsAsync();
    public Task<List<ProductDto>> GetProductsAsync(int skip, int take);
    public Task<ProductDto> UpdateProductStockAsync(Guid id, int newStock);
    
    /// <summary>
    /// Enqueues update request
    /// </summary>
    /// <param name="updateProductDto"></param>
    /// <returns></returns>
    public Task QueueUpdateProductStockAsync(UpdateProductDto updateProductDto);
    public Task<ProductDto> CreateProductAsync(ProductDto newProduct);
}