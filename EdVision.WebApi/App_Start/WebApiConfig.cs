﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EdVision
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) {
            // Конфигурация и службы веб-API
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "ActionableApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
