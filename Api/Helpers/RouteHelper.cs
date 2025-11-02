using Data.Entities;

namespace Api.Helpers;

internal static class RouteHelper
{
    /// <summary>
    /// Creates routes for endpoint groups. 
    /// </summary>
    /// <param name="apiVersion"></param>
    /// <param name="controller"></param>
    /// <returns>$"{apiVersion}/{controller}"</returns>
    public static string GetControllerRoute(string apiVersion, string controller) => $"{apiVersion}/{controller}";
}