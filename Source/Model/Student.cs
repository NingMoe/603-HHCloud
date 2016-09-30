using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.Model
{
    public class Student : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public Student() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置学生姓别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 获取或设置学生的年级编号
        /// </summary>
        public int? Grade { get; set; }
        /// <summary>
        /// 获取或设置出生日期
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 获取或设置身份证号
        /// </summary>
        public string IDNumber { get; set; }
        /// <summary>
        /// 获取或设置民族编号
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 获取或设置学生来源编号
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 获取或设置学生的学校
        /// </summary>
        public string FacilityID { get; set; }
        /// <summary>
        /// 获取或设置学生的班级编号
        /// </summary>
        public string ClassID { get; set; }
        /// <summary>
        /// 获取或设置学生的班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 获取或设置学生的住址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置学生的备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 克隆一个复本
        /// </summary>
        /// <returns></returns>
        public Student Clone()
        {
            return this.MemberwiseClone() as Student;
        }
        #endregion
    }
}
