using Domain.DTOs;
using Domain.Messaging;
using Domain.Repositories;

namespace Domain.Providers;

public sealed class ProductService (IProductRepository repository, IQueueProducer<UpdateProductDto> kafkaProducer) : IProductService
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IQueueProducer<UpdateProductDto> _kafkaProducer = kafkaProducer ?? throw new ArgumentNullException(nameof(kafkaProducer));

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

    /// <inheritdoc/>
    public async Task QueueUpdateProductStockAsync(UpdateProductDto updateProductDto)
    {
        await _kafkaProducer.PublishAsync(updateProductDto);
    }
    
    public async Task<ProductDto> CreateProductAsync(ProductDto newProduct)
    {
        return await _repository.CreateProductAsync(newProduct);
    }
}