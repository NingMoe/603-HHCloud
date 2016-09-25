using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HH.TiYu.Cloud.Controller
{
    public class ValueController : ApiController
    {
        public string Get(string id)
        {
            return "http get " + id;
        }

        public string Get()
        {
            return "http get";
        }
    }
}
