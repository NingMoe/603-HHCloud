using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model.Security;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class OperatorBLL : BLLBase<string, Operator>
    {
        #region 构造函数
        public OperatorBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 实例方法
        /// <summary>
        /// 登录验证
        /// </summary>
        public bool Authentication(string logName, string pwd)
        {
            Operator info = GetByID(logName).QueryObject;
            if (info != null)
            {
                if (info.ID == logName && info.Password == pwd)
                {
                    Operator.Current = info;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override CommandResult Delete(Operator info)
        {
            if (info.CanDelete)
            {
                return base.Delete(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统默认操作员,不能删除");
            }
        }
        #endregion
    }
}
