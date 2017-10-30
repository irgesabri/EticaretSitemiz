using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EticaretSitemiz
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{islem}/{deger}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, islem=UrlParameter.Optional,deger=UrlParameter.Optional}
                //http://Localhost/Yonetim/Index/Urunekle/Sil/1
            );
            
        }
    }
}
