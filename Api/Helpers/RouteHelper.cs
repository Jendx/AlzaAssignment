using Data.Entities;

namespace Api.Helpers;

public static class RouteHelper
{
    public static string GetControllerRoute(string apiVersion, string controller) => $"{apiVersion}/{controller}";
}