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
    public class StudentWX : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public StudentWX() { }
        #endregion

        #region 公共属性
        public string ID { get; set; }

        public string PublicWX { get; set; }

        public string StudentID { get; set; }
        #endregion
    }
}
