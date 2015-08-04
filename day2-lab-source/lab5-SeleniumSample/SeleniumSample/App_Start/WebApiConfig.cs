using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MessageHandlerLib;

namespace SeleniumSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //todo by joey, 註冊 message handler
            config.MessageHandlers.Add(new XmasMessageHandler());
        }
    }
}