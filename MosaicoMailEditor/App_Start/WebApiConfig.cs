using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MosaicoMailEditor
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MailTemplates",
                routeTemplate: "api/{controller}/{key}",
                defaults: new { key = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
