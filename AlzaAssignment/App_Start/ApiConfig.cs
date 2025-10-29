using System.Web.Http;

namespace AlzaAssignment;

internal static class ApiConfig
{
    /// <summary>
    /// Adds mapping for http routes
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public static HttpConfiguration UseRoutes(this HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        
        return config;
    }
}