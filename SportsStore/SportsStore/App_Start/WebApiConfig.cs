using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SportsStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //HttpConfiguration class provides properties and methods to configure different aspects of the way that Web API works

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //configuring serialization to Json only
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
