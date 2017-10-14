using ContosoConsultancy.Rest.Filters;
using System.Configuration;
using System.Web.Http;

namespace ContosoConsultancy.Rest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var delay = int.Parse(ConfigurationManager.AppSettings["SlowResultFilter.Delay"] ?? "0");
            if(delay > 0)
                config.Filters.Add(new SlowResultFilter(delay));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
