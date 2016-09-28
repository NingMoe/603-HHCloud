using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace HH.TiYu.Cloud.WebApi.Host
{
    public class WebApiConfig
    {
        public static void Config(HttpSelfHostConfiguration config)
        {
            var xml = config.Formatters.XmlFormatter;
            xml.UseXmlSerializer = true;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "V1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            config.EnsureInitialized();
        }
    }
}