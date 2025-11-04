using Api.Helpers;
using Domain.Providers;

namespace Api.Endpoints.V2;

internal static class ProductEndpointsV2
{
    public static IEndpointRouteBuilder MapProductEndpointsV2(this IEndpointRouteBuilder endpoints)
    {
        var endpointRoute = RouteHelper.GetControllerRoute(Constants.ApiVersions.V2, Constants.Endpoints.PRODUCT);
        var group = endpoints.MapGroup(endpointRoute);
        group.MapGet("/", async (IProductProvider provider, int skip = 0, int take = 10) =>
            {
                var products = await provider.GetAllProductsAsync();
                return Results.Ok(products);
            })
            .WithName("GetAllProductsV2")
            .WithDescription("Returns max 10 products by default");

        return endpoints;
    }
}