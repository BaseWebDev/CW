using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication {
    public class RouteConfig {
        const string prdContr = @"Products";
        const string prdList = @"List";
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new {
                    controller = prdContr,
                    action = prdList,
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = prdContr, action = prdList, category = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = prdContr, action = prdList, page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = prdContr, action = prdList },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
            
        }
    }
}
