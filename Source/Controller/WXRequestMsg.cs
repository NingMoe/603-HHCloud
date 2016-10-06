using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.WX
{
    /// <summary>
    /// 表示微信发过来的消息
    /// </summary>
    [XmlRoot(ElementName="xml")]
    public class WXRequestMsg
    {
        #region 构造函数
        public WXRequestMsg ()
        { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置消息的接收者，即公众号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 获取或设置消息的发送者，一般是发送者的USERID
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 获取或设置消息创建的时间
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 获取或设置消息ID
        /// </summary>
        public string MsgID { get; set; }
        /// <summary>
        /// 获取或设置消息类别，不同的消息类别有不同的内容及属性
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 获取或设置文本消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 获取或设置图片消息的图片链接
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 获取或设置多媒体消息的媒体ID
        /// </summary>
        public string MediaID { get; set; }

        #region 事件消息的属性
        /// <summary>
        /// 获取或设置具体的事件类型
        /// </summary>
        public string Event { get; set; }

        public string EventKey { get; set; }
        #endregion

        #region 位置消息的属性
        /// <summary>
        /// 获取或设置位置的X座标，经度
        /// </summary>
        public string Location_X { get; set; }
        /// <summary>
        /// 获取或设置位置的Y座标，纬度
        /// </summary>
        public string Location_Y { get; set; }
        /// <summary>
        /// 获取或设置缩放比例
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 获取或设置位置的描述信息
        /// </summary>
        public string Label { get; set; }
        #endregion

        #region 链接消息的属性
        /// <summary>
        /// 获取或设置链接消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 获取或设置链接消息的URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 获取或设置消息的描述
        /// </summary>
        public string Description { get; set; }
        #endregion

        #endregion
    }


}
