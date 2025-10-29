using System.ComponentModel.DataAnnotations;
using Api.Commands;
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
        
        group.MapPost("/", ( CreateProductCommand createCommand) =>
        {

            

        }).WithName("CreateProduct");

        group.MapPatch("/", ([Required] UpdateProductStockCommand createCommand) =>
        {



        }).WithName("UpdateProductStock")
        .WithDisplayName("Update Product")
        .WithDescription("Allows updates of product stock");
        
        return endpoints;
    }
}