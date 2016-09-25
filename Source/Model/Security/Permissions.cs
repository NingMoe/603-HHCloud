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
        /// 区域资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export, Description = "区域信息")]
        Division,
        /// <summary>
        /// 学校资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export | PermissionActions.Import, Description = "学校信息")]
        Facility,
        /// <summary>
        /// 学生资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export | PermissionActions.Import, Description = "学生信息")]
        Student,
        /// <summary>
        /// 测试项目
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export, Description = "测试项目")]
        PhysicalItem,
        /// <summary>
        /// 学生成绩
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export | PermissionActions.Import | PermissionActions.Collect | PermissionActions.Print, Description = "学生成绩")]
        StudentScore,
        /// <summary>
        /// 考试科目选择
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "考试科目选择")]
        ProjectPhysical,
        /// <summary>
        /// 评分标准
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Export | PermissionActions.Import, Description = "评分标准")]
        Standard,
        /// <summary>
        /// 统计报表
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Export, Description = "统计报表")]
        Statistics,
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
