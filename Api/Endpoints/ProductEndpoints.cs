using System.ComponentModel.DataAnnotations;
using Api.Commands;
using Api.Mappers;
using Domain.Providers;
using Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

internal static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup(Constants.Endpoints.PRODUCT_API_ENDPOINT);
        group.MapGet("/", () =>
        {
            
        }).WithName("GetAllProducts");
        
        group.MapGet("/{id:guid}", ([Required] Guid id) =>
        {
            
        }).WithName("GetProduct");
        
        group.MapPost("/", async (CreateProductCommand createCommand, IProductProvider provider) =>
        {
            var newProduct = ProductCommandMapper.ToProductDto(createCommand);
            var createdProduct = await provider.CreateProductAsync(newProduct);

            return Results.Ok(createdProduct);
        }).WithName("CreateProduct");

        group.MapPatch("/", (UpdateProductStockCommand updateCommand, IProductProvider provider) =>
        {
            provider.UpdateProductStockAsync(updateCommand.Id, updateCommand.NewStock);

        }).WithName("UpdateProductStock")
        .WithDisplayName("Update Product")
        .WithDescription("Allows updates of product stock");
        
        return endpoints;
    }
}