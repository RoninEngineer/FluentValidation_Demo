using FluentValidation.WebApi;
using FluentValidation_Demo.Filters;
using System.Web.Http;

namespace FluentValidation_Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Configure Fluent validation
            FluentValidationModelValidatorProvider.Configure(config);
            config.Filters.Add(new ValidateModelStateFilter());

            // Web API configuration and services

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
