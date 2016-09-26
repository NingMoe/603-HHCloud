using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class StudentWXBLL : BLLBase<string, StudentWX>
    {
        #region 构造函数
        public StudentWXBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(StudentWX info)
        {
            return base.Delete(info);
        }
        #endregion
    }
}
