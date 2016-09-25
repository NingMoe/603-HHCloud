using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HH.TiYu.Cloud.Model.Security
{
    public class PermissionActionDescription
    {
        public static string GetDescription(PermissionActions actions)
        {
            string ret = string.Empty;
            for (int i = 0; i < 32; i++)
            {
                PermissionActions temp = (PermissionActions)(1 << i);
                if (Enum.IsDefined(typeof(PermissionActions), temp))
                {
                    if ((temp & actions) != 0)
                    {
                        string descr = GetDescription1(temp);
                        if (!string.IsNullOrEmpty(descr)) ret += descr + ",";
                    }
                }
            }
            ret = ret.TrimEnd(',');
            return ret;
        }

        private static string GetDescription1(PermissionActions action)
        {
            switch (action)
            {
                case PermissionActions.Read:
                    return "查看";
                case PermissionActions.Edit:
                    return "编辑";
                case PermissionActions.Import:
                    return "导入";
                case PermissionActions.Export:
                    return "导出";
                case PermissionActions.Print:
                    return "打印";
                case PermissionActions.Backup:
                    return "备分";
                case PermissionActions.Restore:
                    return "恢复";
                case PermissionActions.Collect :
                    return "采集";
                default:
                    return string.Empty;
            }
        }
    }
}
