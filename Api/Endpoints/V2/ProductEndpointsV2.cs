using System.ComponentModel.DataAnnotations;
using Api.Commands;
using Api.Helpers;
using Api.Mappers;
using Domain.Providers;

namespace Api.Endpoints.V2;

internal static class ProductEndpointsV2
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var endpointRoute = RouteHelper.GetControllerRoute(Constants.ApiVersions.V2, Constants.Endpoints.PRODUCT);
        var group = endpoints.MapGroup(endpointRoute);
        group.MapGet("/", async (IProductProvider provider, int skip = 0, int take = 10) =>
        {
            var products = await provider.GetAllProductsAsync();
            return Results.Ok(products);
        }).WithName("GetAllProducts").WithDescription("Returns max 10 products by default");
        
        return endpoints;
    }
}