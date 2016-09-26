using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
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

        #region 重写基类方法
        public override CommandResult Delete(PublicWX info)
        {
            return base.Delete(info);
        }
        #endregion
    }
}
