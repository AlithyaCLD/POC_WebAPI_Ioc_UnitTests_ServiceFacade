using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Configuration;

namespace TRServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var appSettings = ConfigurationManager.AppSettings;
            var cors = appSettings["CORS"];

            if (!string.IsNullOrEmpty(cors))
            {

                var corsAttr = new EnableCorsAttribute(cors, headers: "*", methods: "*");
                config.EnableCors(corsAttr);
            }

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
