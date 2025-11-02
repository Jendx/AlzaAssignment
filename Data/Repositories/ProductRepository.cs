using Data.Context;
using Data.Mappers;
using Domain.DTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Repositories;

public sealed class ProductRepository(ProductDbContext context, ILogger<ProductRepository> logger) : IProductRepository
{
    private readonly ProductDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly ILogger<ProductRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    /// <summary>
    /// Gets product with the specified <paramref name="productId"/>
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<ProductDto> GetProductAsync(Guid productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        if (product is null)
        {
            var error = new NullReferenceException("Product not found");
            _logger.LogError(error, "Product '{ProductId}' not found", productId);
            throw error;
        };
        
        return ProductMapper.ToProductDto(product);
    }
    
    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns></returns>
    public async Task<List<ProductDto>> GetProductsAsync(int skip = 0, int take = 50)
    {
        var products = await _context.Products
            .Skip(skip)
            .Take(take)
            .Select(x => ProductMapper.ToProductDto(x))
            .ToListAsync();
        
        return products;
    }
    
    /// <summary>
    /// Updates stock of the specified product
    /// </summary>
    /// <returns></returns>
    public async Task<ProductDto> UpdateProductStockAsync(Guid productId, int newStock)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        if (product is null)
        {
            var error = new NullReferenceException("Product not found");
            _logger.LogError(error, "Failed to update product '{ProductId}'. Product not found", productId);
            throw error;
        }

        product.Stock = newStock;
        await _context.SaveChangesAsync();
        
        return ProductMapper.ToProductDto(product);
    }
    
    /// <summary>
    /// Updates stock of the specified product
    /// </summary>
    /// <returns></returns>
    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var newProduct = ProductMapper.ToProduct(productDto);
        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();

        var addedProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == productDto.Id);
        if (addedProduct is null)
        {
            var error = new NullReferenceException("Product not found");
            _logger.LogError(error, "Newly created product {ProductDtoId} was not found", productDto.Id);
            throw error;
        }
        
        return ProductMapper.ToProductDto(addedProduct);
    }
}
