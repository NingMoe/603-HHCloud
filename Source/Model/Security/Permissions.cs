using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HH.TiYu.Cloud.Model.Security
{
    /// <summary>
    /// 操作员的权限枚举
    /// </summary>
    public enum Permission
    {
        #region 基本资料
        /// <summary>
        /// 查看系统选项
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "系统选项")]
        SystemOptions = 1,
        /// <summary>
        /// 微信公众号
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export, Description = "微信公众号")]
        PublicWX,
        /// <summary>
        /// 学生资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export | PermissionActions.Import, Description = "学生信息")]
        Student,
        /// <summary>
        /// 学生成绩
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export | PermissionActions.Import | PermissionActions.Collect | PermissionActions.Print, Description = "学生成绩")]
        StudentScore,
        /// <summary>
        /// 操作日志
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Export, Description = "操作日志")]
        Log,
        #endregion

        #region 安全
        /// <summary>
        /// 操作员资料
        /// </summary>
        [OperatorRight(Catalog = "安全", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export, Description = "操作员")]
        Operator = 200,
        /// <summary>
        /// 查看角色资料
        /// </summary>
        [OperatorRight(Catalog = "安全", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export, Description = "角色")]
        Role,
        #endregion
    }
}
