using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPICRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //enable cors requests 
            config.EnableCors();
            //config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
