using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.Model
{
    public class StudentScore : LJH.GeneralLibrary.Core.DAL.IEntity<long>
    {
        #region 构造函数
        public StudentScore() { }
        #endregion

        #region 公共属性
        public long ID { get; set; }
        /// <summary>
        /// 获取或设置学生学号
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 获取或设置学生成绩的年级
        /// </summary>
        public int  Grade { get; set; }
        /// <summary>
        /// 获取或设置考试项目
        /// </summary>
        public string ProjectID { get; set; }
        /// <summary>
        /// 获取或设置测试项目
        /// </summary>
        public int PhysicalItem { get; set; }
        /// <summary>
        /// 获取或设置测试项目名称
        /// </summary>
        public string PhysicalName { get; set; }
        /// <summary>
        /// 获取或设置测试项目单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置成绩
        /// </summary>
        public string Score { get; set; }
        /// <summary>
        /// 获取或设置得分
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 获取或设置等级
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// 获取或设置加分
        /// </summary>
        public string Jiafen { get; set; }

        public DateTime? UpdateDate { get; set; }
        #endregion
    }
}
