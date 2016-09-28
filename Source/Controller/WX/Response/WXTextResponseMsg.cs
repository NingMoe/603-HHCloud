using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.WebApi.WX.Response
{
    public class WXTextResponseMsg : WXResponseMsgBase
    {
        #region 构造函数
        public WXTextResponseMsg() { }
        #endregion

        #region 公共属性
        public string Content { get; set; }
        #endregion
        public override string ToXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("@<xml>");
            sb.AppendLine(string.Format(@"<ToUserName><![CDATA[{0}]]></ToUserName>", ToUserName));
            sb.AppendLine(string.Format(@"<FromUserName><![CDATA[{0}]]></FromUserName>", FromUserName));
            sb.AppendLine(string.Format(@"<CreateTime>{0}</CreateTime>", CreateTime));
            sb.AppendLine(string.Format(@"<MsgType><![CDATA[text]]></MsgType>"));
            sb.AppendLine(string.Format(@"<Content><![CDATA[{0}]]></Content>", Content));
            sb.AppendLine("@</xml>");
            return sb.ToString();
        }
    }
}
