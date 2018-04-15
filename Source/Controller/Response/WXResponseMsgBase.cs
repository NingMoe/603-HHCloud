using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.WX.Response
{
    /// <summary>
    /// 表示微信回复消息基类
    /// </summary>
    public abstract class WXResponseMsgBase
    {
        #region  公共属性
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public DateTime CreateTime { get; set; }

        public string MsgType { get; set; }
        #endregion

        public abstract string ToXML();
    }
}
