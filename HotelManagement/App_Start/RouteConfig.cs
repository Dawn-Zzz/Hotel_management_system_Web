﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HotelManagement.Controllers" }
            );

            routes.MapRoute(
                name: "AdminDefault",
                url: "Admin/{id}",
                defaults: new { controller = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "YourNamespace.Controllers" }
            );

            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HotelManagement.Controllers" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MyApplication.Areas.MyArea.Controllers" }
            );

            routes.MapRoute(
                name: "Registration",
                url: "Registration/{controller}/{action}/{id}",
                defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MyApplication.Areas.MyArea.Controllers" }
            );
        }
    }
}
