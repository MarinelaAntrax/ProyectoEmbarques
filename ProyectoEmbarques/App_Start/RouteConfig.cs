using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoEmbarques
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Shipping_Records", action = "Create", id = UrlParameter.Optional },
                 namespaces: new[] { "ProyectoEmbarques.Controllers" }
            );

            routes.MapRoute(
                name: "EmbarqueEnsambles",
                url: "Shipping_Records/{action}/{id}",
                defaults: new { controller = "Shipping_Records", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Clientes",
                 url: "Clientes/{action}/{id}",
                 defaults: new { controller = "Clientes", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Ensambles",
                url: "Ensambles/{action}/{id}",
                defaults: new { controller = "Ensambles", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EnsamblesRealizados",
                url: "EnsamblesRealizados/{action}/{id}",
                defaults: new { controller = "EnsamblesRealizados", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
