using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.TiYu.Cloud.WebApi.WX.Response;

namespace HH.TiYu.Cloud.WebApi.WX
{
    public class WXRequestHandler
    {
        #region 构造函数

        #endregion

        #region 私有方法 
        public long GetCreateTime(DateTime dt)
        {
            return (long)(new TimeSpan(dt.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks).TotalSeconds);
        }
        #endregion

        #region 公共方法 
        public WXResponseMsgBase HandleMsg(WXRequestMsg msg)
        {
            if (msg.MsgType == MsgType.Text)
            {
                return new WXTextResponseMsg()
                {
                    ToUserName = msg.FromUserName,
                    FromUserName = msg.ToUserName,
                    CreateTime = GetCreateTime(DateTime.Now),
                    Content = "你发的消息是 " + msg.Content,
                };
            }
            return null;
        }
        #endregion
    }
}
