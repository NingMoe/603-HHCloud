using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.BLL;

namespace HH.TiYu.Cloud.WX
{
    public class WXManager
    {
        public static WXManager Current { get; set; }

        #region 构造函数
        public WXManager(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri = null;
        private ReaderWriterLock _WXSLocker = new ReaderWriterLock();
        private Dictionary<string, PublicWX> _WXS = new Dictionary<string, PublicWX>();
        private Thread _TGetAccessKey = null;
        #endregion

        #region 私有方法
        private async void GetAccessKey_Thread()
        {
            int sleepSeconds = 30; //秒
            Thread.Sleep(5000);
            while (true)
            {
                List<PublicWX> wxs = null;
                _WXSLocker.AcquireReaderLock(int.MaxValue);
                if (_WXS != null && _WXS.Count > 0) wxs = _WXS.Values.ToList();
                _WXSLocker.ReleaseReaderLock();
                if (wxs != null && wxs.Count > 0)
                {
                    foreach (var wx in wxs)
                    {
                        try
                        {
                            if (wx.AccessTokenExpireTime == null || wx.AccessTokenExpireTime <= DateTime.Now.AddSeconds(-sleepSeconds * 2))
                            {
                                var key = await new WXClient().GetAccessKeyAsync(wx);
                                if (key != null) new PublicWXBLL(_RepoUri).UpdateAccessToken(wx, key.access_token, DateTime.Now, DateTime.Now.AddSeconds(key.expires_in));
                            }
                        }
                        catch (Exception ex)
                        {
                            LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                        }
                    }
                }
                Thread.Sleep(sleepSeconds * 1000);
            }
        }
        #endregion

        #region 公共方法
        public void Init()
        {
            var items = new PublicWXBLL(_RepoUri).GetItems(null).QueryObjects;
            _WXSLocker.AcquireWriterLock(int.MaxValue);
            _WXS.Clear();
            if (items != null && items.Count > 0)
            {
                items.ForEach(it => _WXS.Add(it.ID, it));
            }
            _WXSLocker.ReleaseWriterLock();
            if (_TGetAccessKey == null)
            {
                _TGetAccessKey = new Thread(new ThreadStart(GetAccessKey_Thread));
                _TGetAccessKey.IsBackground = true;
                _TGetAccessKey.Start();
            }
        }

        public void Add(PublicWX wx)
        {
            _WXSLocker.AcquireWriterLock(int.MaxValue);
            if (_WXS.ContainsKey(wx.ID)) _WXS.Remove(wx.ID);
            _WXS.Add(wx.ID, wx);
            _WXSLocker.ReleaseWriterLock();
        }

        public void Remove(PublicWX wx)
        {
            _WXSLocker.AcquireWriterLock(int.MaxValue);
            if (_WXS.ContainsKey(wx.ID)) _WXS.Remove(wx.ID);
            _WXSLocker.ReleaseWriterLock();
        }

        public PublicWX this[string id]
        {
            get
            {
                PublicWX ret = null;
                _WXSLocker.AcquireReaderLock(int.MaxValue);
                if (_WXS.ContainsKey(id)) ret = _WXS[id];
                _WXSLocker.ReleaseReaderLock();
                return ret;
            }
        }
        #endregion
    }
}