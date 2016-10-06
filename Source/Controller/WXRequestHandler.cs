using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.WX.Response;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.Model.SearchCondition;
using HH.TiYu.Cloud.BLL;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.WX
{
    public class WXRequestHandler
    {
        #region 构造函数

        #endregion

        //private string _DefaultResponse = "你可以进行如下操作:\n" +
        //                                    "绑定学号请发送  \"@@\" + 学号\n" +
        //                                    "如  @@12345678 \n" +
        //                                    "取消绑定请发送  \"@！\"\n" +
        //                                    "查询绑定的学号请发送  \"@？\"\n" +
        //                                    "查询成绩请发送  \"？？\"";
        private string _DefaultResponse = "相信汇海，相信专业！\n";
        private string _regStudentID = "@@";
        private string[] _unregStudentID = new string[] { "@!", "@！" };
        private string[] _queryregStudentID = new string[] { "@?", "@？" };
        private string[] _queryScore = new string[] { "??", "？？" };
        private static ConcurrentDictionary<string, string> _WaitingEvents = new ConcurrentDictionary<string, string>(); //用于保存用户的待处理事件

        #region 私有方法 
        private long GetCreateTime(DateTime dt)
        {
            return (long)(new TimeSpan(dt.Ticks - new DateTime(1970, 1, 1, 8, 0, 0).Ticks).TotalSeconds);
        }

        private WXResponseMsgBase 绑定学号(string publicWX, WXRequestMsg msg)
        {
            string response = "请输入你要绑定的学号";
            if (!string.IsNullOrEmpty(msg.Content))
            {
                string sid = null;
                if (msg.Content.IndexOf(_regStudentID) == 0 && msg.Content.Length > _regStudentID.Length) sid = msg.Content.Substring(_regStudentID.Length); //
                else sid = msg.Content; //通过菜单项然后输入学号
                var ret = new WXBindingBLL(AppSettings.Current.ConnStr).Register(msg.FromUserName, msg.ToUserName, sid);
                if (ret.Result == ResultCode.Successful) response = string.Format("你已经成功绑定学号 {0}", sid);
                else response = ret.Message;
            }
            return new WXTextResponseMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                CreateTime = GetCreateTime(DateTime.Now),
                Content = response
            };
        }

        private WXResponseMsgBase 取消绑定(string publicWX, WXRequestMsg msg)
        {
            string response = _DefaultResponse;
            var ret = new WXBindingBLL(AppSettings.Current.ConnStr).UnRegister(msg.FromUserName, msg.ToUserName);
            if (ret.Result == ResultCode.Successful) response = "你已经成功取消学号绑定";
            else response = ret.Message;

            return new WXTextResponseMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                CreateTime = GetCreateTime(DateTime.Now),
                Content = response
            };
        }

        private WXResponseMsgBase 查询绑定(string publicWX, WXRequestMsg msg)
        {
            string response = _DefaultResponse;

            var sid = new WXBindingBLL(AppSettings.Current.ConnStr).GetBindingStudentID(msg.FromUserName, msg.ToUserName);
            if (string.IsNullOrEmpty(sid)) response = "您还没有绑定学号。";
            else
            {
                var wx = WXManager.Current[publicWX];
                if (wx == null) response = "系统没有提供此微信公众号服务";
                else
                {
                    var s = new StudentBLL(wx.DBConnect).GetByID(sid).QueryObject;
                    if (s == null) response = string.Format("学号：{0}\n{1}", sid, "没有找到学生信息");
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format("学号：{0}", s.ID));
                        sb.AppendLine(string.Format("姓名：{0}", s.Name));
                        if (s.Grade.HasValue) sb.AppendLine(string.Format("年级：{0}", GradeHelper.Instance.GetName(s.Grade.Value)));
                        if (!string.IsNullOrEmpty(s.ClassName)) sb.AppendLine(string.Format("班级：{0}", s.ClassName));
                        response = sb.ToString();
                    }
                }
            }
            return new WXTextResponseMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                CreateTime = GetCreateTime(DateTime.Now),
                Content = response
            };
        }

        private WXResponseMsgBase 查询成绩(string publicWX, WXRequestMsg msg)
        {
            string response = _DefaultResponse;
            var sid = new WXBindingBLL(AppSettings.Current.ConnStr).GetBindingStudentID(msg.FromUserName, msg.ToUserName);
            if (string.IsNullOrEmpty(sid)) response = "您还没有绑定学号，请先绑定学号";
            else
            {
                var wx = WXManager.Current[publicWX];
                if (wx == null) response = "系统没有提供此微信公众号服务";
                else
                {
                    var s = new StudentBLL(wx.DBConnect).GetByID(sid).QueryObject;
                    if (s == null) response = "没有找到学生信息";
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format("学号：{0}", s.ID));
                        sb.AppendLine(string.Format("姓名：{0}", s.Name));
                        if (s.Grade.HasValue) sb.AppendLine(string.Format("年级：{0}", GradeHelper.Instance.GetName(s.Grade.Value)));
                        if (!string.IsNullOrEmpty(s.ClassName)) sb.AppendLine(string.Format("班级：{0}", s.ClassName));
                        var con = new StudentScoreSearchCondition() { Grade = s.Grade, StudentID = s.ID, ProjectID = "TizhiCheshi" };
                        var scores = new StudentScoreBLL(wx.DBConnect).GetItems(con).QueryObjects;
                        scores = (from it in scores orderby it.PhysicalItem ascending select it).ToList();
                        foreach (var score in scores)
                        {
                            if (string.IsNullOrEmpty(score.Result)) sb.AppendLine(string.Format("{0}：{1}", score.PhysicalName, score.Score));
                            else sb.AppendLine(string.Format("{0}：{1}_{2}分_{3}", score.PhysicalName, score.Score, score.Result, score.Rank));
                        }
                        response = sb.ToString();
                    }
                }
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
                              "相信汇海，相信专业！\n";
            //"\n" +
            //"接下来 \n" +
            //_DefaultResponse;
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
        public WXResponseMsgBase HandleMsg(string publicWX, WXRequestMsg msg)
        {
            if (msg.MsgType == MsgType.Event)
            {
                string temp = null;
                _WaitingEvents.TryRemove(msg.FromUserName, out temp);  //如果是事件
                if (msg.Event == WXEventType.Subscribe) return HandleSubscribeMsg(msg);
                else if (msg.Event == WXEventType.Click)
                {
                    switch (msg.EventKey)
                    {
                        case "btn_绑定学号":
                            {
                                _WaitingEvents[msg.FromUserName] = msg.EventKey;
                                return 绑定学号(publicWX, msg);
                            }
                        case "btn_取消绑定":
                            {
                                _WaitingEvents[msg.FromUserName] = msg.EventKey;
                                return new WXTextResponseMsg()
                                {
                                    ToUserName = msg.FromUserName,
                                    FromUserName = msg.ToUserName,
                                    CreateTime = GetCreateTime(DateTime.Now),
                                    Content = "是否取消绑定？确定取消请回复 \"是\""
                                };
                            }
                        case "btn_查询学号": return 查询绑定(publicWX, msg);
                        case "btn_查询成绩": return 查询成绩(publicWX, msg);
                    }
                }
            }
            else if (msg.MsgType == MsgType.Text)
            {
                if (_WaitingEvents.ContainsKey(msg.FromUserName))
                {
                    string eventKey = null;
                    _WaitingEvents.TryRemove(msg.FromUserName, out eventKey);
                    if (eventKey == "btn_绑定学号") return 绑定学号(publicWX, msg);
                    else if (eventKey == "btn_取消绑定" && msg.Content == "是") return 取消绑定(publicWX, msg);
                }
            }
            return new WXTextResponseMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                CreateTime = GetCreateTime(DateTime.Now),
                Content = _DefaultResponse
            };
        }
        #endregion
    }
}
