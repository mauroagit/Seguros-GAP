using GAP.Seguros.App.Web.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GAP.Seguros.App.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(UnityConfig.Container);
        }
    }
}
