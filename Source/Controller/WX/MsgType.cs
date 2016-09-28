using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.WebApi.WX
{
    public class MsgType
    {
        #region 构造函数

        #endregion

        #region 私有变量
        private static List<string> _AllMsgTypes = new List<string>() { "text", "image", "voice", "event", "location", "link", "event" };
        #endregion

        #region 公共属性和方法
        public static string Text = "text";

        public static string Image = "image";

        public static string Voice = "voice";

        public static string Location = "location";

        public static string Link = "link";

        public static string Event = "event";

        /// <summary>
        /// 检查是否定义了某个消息类别
        /// </summary>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static bool MsgTypeDefined(string msgType)
        {
            return _AllMsgTypes.Contains(msgType);
        }
        #endregion
    }
}
