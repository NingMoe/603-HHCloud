using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class PublicWXBLL : BLLBase<string, PublicWX>
    {
        #region 构造函数
        public PublicWXBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 公共方法
        public CommandResult UpdateAccessToken(PublicWX wx,string act, DateTime actTime, DateTime actExpireTime)
        {
            var newVal = wx.Clone();
            newVal.AccessToken = act;
            newVal.AccessTokenTime = actTime;
            newVal.AccessTokenExpireTime = actExpireTime;
            var ret = ProviderFactory.Create<IProvider<PublicWX, string>>(RepoUri).Update(newVal, wx);
            if (ret.Result == ResultCode.Successful)
            {
                wx.AccessToken = act;
                wx.AccessTokenTime = actTime;
                wx.AccessTokenExpireTime = actExpireTime;
            }
            return ret;
        }
        #endregion
    }
}
