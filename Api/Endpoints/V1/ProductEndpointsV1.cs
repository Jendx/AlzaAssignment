using System.ComponentModel.DataAnnotations;
using Api.Commands;
using Api.Helpers;
using Api.Mappers;
using Domain.Providers;

namespace Api.Endpoints.V1;

internal static class ProductEndpointsV1
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var endpointRoute = RouteHelper.GetControllerRoute(Constants.ApiVersions.V1, Constants.Endpoints.PRODUCT);
        var group = endpoints.MapGroup(endpointRoute);
        group.MapGet("/", async (IProductService service) =>
        {
            var products = await service.GetAllProductsAsync();
            return Results.Ok(products);
        }).WithName("GetAllProducts");
        
        group.MapGet("/{id:guid}", async ([Required] Guid id, IProductService service) =>
        {
            var products = await service.GetProductAsync(id);
            return Results.Ok(products);
        }).WithName("GetProduct");
        
        group.MapPost("/", async (CreateProductCommand createCommand, IProductService service) =>
        {
            var newProduct = ProductCommandMapper.ToProductDto(createCommand);
            var createdProduct = await service.CreateProductAsync(newProduct);

            return Results.Ok(createdProduct);
        }).WithName("CreateProduct");

        group.MapPatch("/", (UpdateProductStockCommand updateCommand, IProductService service) =>
        {
            service.UpdateProductStockAsync(updateCommand.Id, updateCommand.NewStock);

        }).WithName("UpdateProductStock")
        .WithDisplayName("Update Product")
        .WithDescription("Allows updates of product stock");
        
        return endpoints;
    }
}