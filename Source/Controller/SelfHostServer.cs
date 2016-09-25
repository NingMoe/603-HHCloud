using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace HH.TiYu.Cloud.Controller
{
    public class SelfHostServer
    {

        public static void StartWebApiService()
        {
            var uri = new Uri(@"http://localhost:9006/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(uri);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var host = new HttpSelfHostServer(config);
            host.OpenAsync().Wait();
        }
    }
}
