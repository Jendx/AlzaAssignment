using Domain.DTOs;
using Domain.Repositories;

namespace Domain.Providers;

public sealed class ProductService (IProductRepository repository) : IProductService
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<ProductDto> GetProductAsync(Guid id)
    {
        return await _repository.GetProductAsync(id);
    }
    
    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        return await GetProductsAsync(0, int.MaxValue);
    }
    
    public async Task<List<ProductDto>> GetProductsAsync(int skip, int take)
    {
        return await _repository.GetProductsAsync(skip, take);
    }
    
    public async Task<ProductDto> UpdateProductStockAsync(Guid id, int newStock)
    {
        return await _repository.UpdateProductStockAsync(id, newStock);
    }
    
    public async Task<ProductDto> CreateProductAsync(ProductDto newProduct)
    {
        return await _repository.CreateProductAsync(newProduct);
    }
}