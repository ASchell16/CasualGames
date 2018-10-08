using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GameShopAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //remove XMl Formatter. Only use Json
            var xmlFormatter = 
                GlobalConfiguration.Configuration.
                Formatters.XmlFormatter;

            GlobalConfiguration.Configuration.Formatters.Remove(xmlFormatter);
            
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
