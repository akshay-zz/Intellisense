using Intellisense.Filters;
using System.Web.Http;

namespace Intellisense
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Register validation for model
            config.Filters.Add(new ValidateModelAttribute());

            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Action",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
