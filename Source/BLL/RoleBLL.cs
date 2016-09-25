using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model.Security;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class RoleBLL : BLLBase<string, Role>
    {
        #region 构造函数
        public RoleBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(Role info)
        {
            if (info.CanDelete)
            {
                List<Operator> ops = (new OperatorBLL(RepoUri)).GetItems(null).QueryObjects;
                if (ops.Exists(item => item.RoleID == info.ID)) return new CommandResult(ResultCode.Fail, "已经有操作员归属到此角色，不能删除。");
                return base.Delete(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统默认角色不能删除");
            }
        }
        #endregion
    }
}
