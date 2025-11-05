using Api.Commands;
using Api.Helpers;
using Domain.DTOs;
using Domain.Messaging;
using Domain.Providers;

namespace Api.Endpoints.V2;

internal static class ProductEndpointsV2
{
    public static IEndpointRouteBuilder MapProductEndpointsV2(this IEndpointRouteBuilder endpoints)
    {
        var endpointRoute = RouteHelper.GetControllerRoute(Constants.ApiVersions.V2, Constants.Endpoints.PRODUCT);
        var group = endpoints.MapGroup(endpointRoute);
        group.MapGet("/", async (IProductService service, int skip = 0, int take = 10) =>
            {
                var products = await service.GetProductsAsync(skip, take);
                return Results.Ok(products);
            })
            .WithName("GetAllProductsV2")
            .WithDescription("Returns max 10 products by default");

        group.MapPatch("/",
                async (UpdateProductStockCommand updateCommand, IQueueProducer<UpdateProductDto> kafkaProducer) =>
                {
                    await kafkaProducer.PublishAsync(new UpdateProductDto(updateCommand.Id, updateCommand.NewStock));
                }).WithName("QueueProductStockUpdate")
            .WithDisplayName("Enqueue Product stock update")
            .WithDescription("Allows 'bulk' updates of product stock using messaging service");

        return endpoints;
    }
}