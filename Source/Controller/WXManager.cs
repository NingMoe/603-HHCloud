using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.BLL;

namespace HH.TiYu.Cloud.WebApi
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
        #endregion

        #region 私有方法

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
                _WXSLocker.AcquireReaderLock(int.MaxValue);
                if (_WXS.ContainsKey(id)) return _WXS[id];
                _WXSLocker.ReleaseReaderLock();
                return null;
            }
        }
        #endregion
    }
}