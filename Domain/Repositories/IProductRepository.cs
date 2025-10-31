using Domain.DTOs;

namespace Domain.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// Gets product with the specified <paramref name="productId"/>
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public Task<ProductDto> GetProductAsync(Guid productId);

    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns></returns>
    public Task<List<ProductDto>> GetProductsAsync(int skip = 0, int take = 50);

    /// <summary>
    /// updates stock of the specified product
    /// </summary>
    /// <returns></returns>
    public Task<ProductDto> UpdateProductStockAsync(Guid productId, int newStock);

    /// <summary>
    /// updates stock of the specified product
    /// </summary>
    /// <returns></returns>
    public Task<ProductDto> CreateProductAsync(ProductDto productDto);
}