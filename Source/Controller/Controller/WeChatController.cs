using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HH.TiYu.Cloud.WebApi.Controller
{
    public class WXController : ApiController
    {
        /// <summary>
        /// 微信开发 验证服务器地址的有效性
        /// </summary>
        [HttpGet]
        public HttpResponseMessage WeChatServiceValidation(string id, string signature, string timestamp, string nonce, string echostr)
        {
            var response = Request.CreateResponse();
            response.Content = new StringContent(echostr);
            return response;
        }

        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var response = request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
