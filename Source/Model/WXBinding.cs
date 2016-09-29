using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.Model
{
    /// <summary>
    /// 表示学生的微信
    /// </summary>
    public class WXBinding : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        public static string CreateBindingID(string userWX, string publicWX)
        {
            if (!string.IsNullOrEmpty(userWX) && !string.IsNullOrEmpty(publicWX)) return string.Format("{0}_{1}", userWX, publicWX);
            throw new ArgumentException("生成ID的userWX 和 publicWX 都不能为空");
        }
        #region 构造函数
        public WXBinding() { }
        #endregion

        #region 公共属性
        public string ID { get; set; }

        public string UserWX { get; set; }

        public string PublicWX { get; set; }

        public string StudentID { get; set; }
        #endregion
    }
}
