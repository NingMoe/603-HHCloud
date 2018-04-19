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
using System.Xml.Serialization;
using HH.TiYu.Cloud.WX.Response;
using Tencent;

namespace HH.TiYu.Cloud.WX
{
    public class WXQYHController : ApiController
    {
        /// <summary>
        /// 微信开发 验证服务器地址的有效性
        /// </summary>
        [HttpGet]
        public HttpResponseMessage WeChatServiceValidation(string id, string msg_signature, string timestamp, string nonce, string echostr)
        {
            var wx = WXManager.Current[id];
            if (wx != null)
            {
                var wxcpt = new Tencent.WXBizMsgCrypt(wx.Token, wx.EncodingAESKey, wx.AppID);
                string sEchoStr = "";
                var ret = wxcpt.VerifyURL(msg_signature, timestamp, nonce, echostr, ref sEchoStr);
                if (ret == 0)
                {
                    var response = Request.CreateResponse();
                    response.Content = new StringContent(sEchoStr);
                    return response;
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// 微信开发 验证服务器地址的有效性
        /// </summary>
        [HttpGet]
        public WXRequestMsg WeChatServiceValidation(string id)
        {
            var wx = WXManager.Current[id];
            if (wx != null)
            {
                return new WXRequestMsg()
                {
                    FromUserName = "abc",
                    ToUserName = "ljh",
                    MsgType = MsgType.Text,
                    MsgID = "426236363",
                };
            }
            return new WXRequestMsg()
            {
                FromUserName = "没有找到此应用ID",
            };
        }

        /// <summary>
        /// 微信后台消息POST处理函数
        /// </summary>
        /// <param name="id">微信公众号ID，系统可以托管多个公众号，用于区分各个公众号</param>
        /// <param name="msg_signature">微信后台发过来的签名参数，用于验证是否是微信服务器发的消息</param>
        /// <param name="timestamp">微信后台发过来的签名参数，用于验证是否是微信服务器发的消息</param>
        /// <param name="nonce">微信后台发过来的签名参数，用于验证是否是微信服务器发的消息</param>
        /// <param name="msg">微信POST请求中的消息主体内容，后台会自动用XMLFORMATER反序列化</param>
        /// <returns></returns>
        public HttpResponseMessage Post(string id, string msg_signature, string timestamp, string nonce)
        {
            try
            {
                var wx = WXManager.Current[id];
                if (wx != null)
                {
                    var wxcpt = new Tencent.WXBizMsgCrypt(wx.Token, wx.EncodingAESKey, wx.AppID);
                    var content = Request.Content.ReadAsStringAsync().Result;
                    string xml = "";  // 解析之后的明文
                    var ret = wxcpt.DecryptMsg(msg_signature, timestamp, nonce, content, ref xml);
                    if (ret == 0)
                    {
                        var stream = new StringReader(xml);
                        WXRequestMsg msg = new XmlSerializer(typeof(WXRequestMsg)).Deserialize(stream) as WXRequestMsg;
                        if (msg != null)
                        {
                            var res = new WXRequestHandler(this.Request).HandleMsg(id, msg);
                            if (res != null)
                            {
                                var response = Request.CreateResponse();
                                string sRespData = res.ToXML();
                                string sEncryptMsg = ""; //xml格式的密文
                                ret = wxcpt.EncryptMsg(sRespData, timestamp, nonce, ref sEncryptMsg);
                                if (ret == 0)
                                {
                                    response.Content = new StringContent(sEncryptMsg);
                                    return response;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Request.CreateResponse();
        }
    }
}
