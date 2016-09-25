using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HH.TiYu.Cloud.Model.Security
{
    /// <summary>
    /// 表示权限的动作
    /// </summary>
    [Flags]
    public enum PermissionActions
    {
        /// <summary>
        /// 没有指定
        /// </summary>
        None = 0,
        /// <summary>
        /// 查看
        /// </summary>
        Read = 0x01,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 0x02,
        /// <summary>
        /// 导入
        /// </summary>
        Import = 0x04,
        /// <summary>
        /// 导出
        /// </summary>
        Export = 0x08,
        /// <summary>
        /// 打印
        /// </summary>
        Print = 0x10,
        /// <summary>
        /// 备分
        /// </summary>
        Backup = 0x20,
        /// <summary>
        /// 恢复
        /// </summary>
        Restore = 0x40,
        /// <summary>
        /// 采集
        /// </summary>
        Collect=0x80,
    }
}
        
