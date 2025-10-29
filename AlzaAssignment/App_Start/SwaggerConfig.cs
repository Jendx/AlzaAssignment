using System.Reflection;
using System.Web.Http;
using Swashbuckle.Application;

namespace AlzaAssignment;

internal static class SwaggerConfig
{
    public static HttpConfiguration UseSwagger(this HttpConfiguration config)
    {
        var applicationName = Assembly.GetExecutingAssembly().FullName;
        config
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", applicationName);
            })
            .EnableSwaggerUi(c =>
            {
                c.DocumentTitle($"{applicationName} API documentation");
                c.DisableValidator();
            });
        
        return config;
    }
}