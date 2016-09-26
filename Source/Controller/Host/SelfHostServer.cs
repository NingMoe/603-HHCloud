using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace HH.TiYu.Cloud.WebApi.Host
{
    //
    //netsh http add urlacl url=http://120.77.11.122:9008/HHCloud/ user=Administrator
    public class SelfHostServer
    {
        
        public static void StartWebApiService()
        {
            var uri = new Uri(@"http://120.77.11.122:9008/HHCloud/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(uri);
            WebApiConfig.Config(config);
            var host = new HttpSelfHostServer(config);
            host.OpenAsync().Wait();
        }
    }
}
