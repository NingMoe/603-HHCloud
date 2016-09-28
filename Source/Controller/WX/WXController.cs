using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using HH.TiYu.Cloud.WebApi.WX.Response;

namespace HH.TiYu.Cloud.WebApi.WX
{
    public class WXController : ApiController
    {
        /// <summary>
        /// 微信开发 验证服务器地址的有效性
        /// </summary>
        [HttpGet]
        public HttpResponseMessage WeChatServiceValidation(string id, string signature, string timestamp, string nonce, string echostr)
        {
            var wx = WXManager.Current[id];
            if (wx != null && wx.GetSigniture(timestamp, nonce).ToUpper() == signature.ToUpper())
            {
                var response = Request.CreateResponse();
                response.Content = new StringContent(echostr);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public WXRequestMsg Get()
        {
            return new WXRequestMsg()
            {
                FromUserName = "abc",
                ToUserName = "ljh",
                MsgType = MsgType.Text,
                MsgID = "426236363",
            };
        }

        /// <summary>
        /// 微信后台消息POST处理函数
        /// </summary>
        /// <param name="id">微信公众号ID，系统可以托管多个公众号，用于区分各个公众号</param>
        /// <param name="signature">微信后台发过来的签名参数，用于验证是否是微信服务器发的消息</param>
        /// <param name="timestamp">微信后台发过来的签名参数，用于验证是否是微信服务器发的消息</param>
        /// <param name="nonce">微信后台发过来的签名参数，用于验证是否是微信服务器发的消息</param>
        /// <param name="msg">微信POST请求中的消息主体内容，后台会自动用XMLFORMATER反序列化</param>
        /// <returns></returns>
        public HttpResponseMessage Post(string id, string signature, string timestamp, string nonce, WXRequestMsg msg)
        {
            try
            {
                var wx = WXManager.Current[id];
                if (wx == null || wx.GetSigniture(timestamp, nonce).ToUpper() != signature.ToUpper())
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                if (msg != null)
                {
                    var ret = new WXRequestHandler().HandleMsg(msg);
                    if (ret != null)
                    {
                        var response = Request.CreateResponse();
                        response.Content = new StringContent(ret.ToXML());
                        return response;
                    }
                    return Request.CreateResponse();
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError("消息不能解析"));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }
    }
}
