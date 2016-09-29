using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.TiYu.Cloud.WebApi.WX.Response;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.BLL;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.WebApi.WX
{
    public class WXRequestHandler
    {
        #region 构造函数

        #endregion

        private string _DefaultResponse = "你可以进行如下操作:\n" +
                                            "绑定学号请发送  \"@@\" + 学号\n" +
                                            "如  @@12345678 \n" +
                                            "取消绑定请发送  \"@！\"\n" +
                                            "查询绑定的学号请发送  \"@？\"\n" +
                                            "查询成绩请发送  \"？？\"";
        private string _regStudentID = "@@";
        private string[] _unregStudentID = new string[] { "@!", "@！" };
        private string[] _queryregStudentID = new string[] { "@?", "@？" };

        #region 私有方法 
        private long GetCreateTime(DateTime dt)
        {
            return (long)(new TimeSpan(dt.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks).TotalSeconds);
        }

        private WXResponseMsgBase HandleTextMsg(WXRequestMsg msg)
        {
            string response = _DefaultResponse;
            if (msg.Content.IndexOf(_regStudentID) == 0 && msg.Content.Length > _regStudentID.Length)
            {
                string sid = msg.Content.Substring(_regStudentID.Length); //
                var ret = new WXBindingBLL(AppSettings.Current.ConnStr).Register(msg.FromUserName, msg.ToUserName, sid);
                if (ret.Result == ResultCode.Successful) response = string.Format("你已经成功绑定学号 {0}", sid);
                else response = ret.Message;
            }
            else if (_unregStudentID.Contains(msg.Content))
            {
                var ret = new WXBindingBLL(AppSettings.Current.ConnStr).UnRegister(msg.FromUserName, msg.ToUserName);
                if (ret.Result == ResultCode.Successful) response = "你已经成功取消学号绑定";
                else response = ret.Message;
            }
            else if (_queryregStudentID.Contains(msg.Content))
            {
                var sid = new WXBindingBLL(AppSettings.Current.ConnStr).GetBindingStudentID(msg.FromUserName, msg.ToUserName);
                if (string.IsNullOrEmpty(sid)) response = "没有查询到绑定学号，请确定是否已经绑定过学号";
                else response = string.Format("你绑定的学号是 {0}", sid);
            }
            return new WXTextResponseMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                CreateTime = GetCreateTime(DateTime.Now),
                Content = response
            };
        }

        private WXResponseMsgBase HandleSubscribeMsg(WXRequestMsg msg)
        {
            string response = "欢迎关注我们！ \n" +
                              "接下来 \n" +
                              _DefaultResponse;
            return new WXTextResponseMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                CreateTime = GetCreateTime(DateTime.Now),
                Content = response
            };
        }
        #endregion

        #region 公共方法 
        public WXResponseMsgBase HandleMsg(WXRequestMsg msg)
        {
            if (msg.MsgType == MsgType.Text)
            {
                return HandleTextMsg(msg);
            }
            else if (msg.MsgType == MsgType.Event)
            {
                if (msg.Event == WXEventType.Subscribe) return HandleSubscribeMsg(msg);
            }
            return null;
        }
        #endregion
    }
}
