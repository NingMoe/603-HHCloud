using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HH.TiYu.Cloud.Model
{
    /// <summary>
    /// 表示年级的集合
    /// </summary>
    public sealed class GradeHelper
    {
        #region 静态变量
        private static GradeHelper _Instance;
        /// <summary>
        /// 获取单例
        /// </summary>
        public static GradeHelper Instance
        {
            get
            {
                if (_Instance == null) _Instance = new GradeHelper();
                return _Instance;
            }
        }
        #endregion

        #region 静态属性
        public static readonly int 一年级 = 11;
        public static readonly int 二年级 = 12;
        public static readonly int 三年级 = 13;
        public static readonly int 四年级 = 14;
        public static readonly int 五年级 = 15;
        public static readonly int 六年级 = 16;

        public static readonly int 初一 = 21;
        public static readonly int 初二 = 22;
        public static readonly int 初三 = 23;

        public static readonly int 高一 = 31;
        public static readonly int 高二 = 32;
        public static readonly int 高三 = 33;

        public static readonly int 大一 = 41;
        public static readonly int 大二 = 42;
        public static readonly int 大三 = 43;
        public static readonly int 大四 = 44;

        public static readonly int 年龄20_24 = 101;
        public static readonly int 年龄25_29 = 102;
        public static readonly int 年龄30_34 = 103;
        public static readonly int 年龄35_39 = 104;
        public static readonly int 年龄40_44 = 105;
        public static readonly int 年龄45_49 = 106;
        public static readonly int 年龄50_54 = 107;
        public static readonly int 年龄55_59 = 108;
        public static readonly int 年龄60_64 = 109;
        public static readonly int 年龄65_69 = 110;
        #endregion

        #region 构造函数
        public GradeHelper()
        {
            _Grades = new Dictionary<int, string>();
            _Grades.Add(11, "一年级");
            _Grades.Add(12, "二年级");
            _Grades.Add(13, "三年级");
            _Grades.Add(14, "四年级");
            _Grades.Add(15, "五年级");
            _Grades.Add(16, "六年级");
            _Grades.Add(21, "初一");
            _Grades.Add(22, "初二");
            _Grades.Add(23, "初三");
            _Grades.Add(31, "高一");
            _Grades.Add(32, "高二");
            _Grades.Add(33, "高三");
            _Grades.Add(41, "大一");
            _Grades.Add(42, "大二");
            _Grades.Add(43, "大三");
            _Grades.Add(44, "大四");

            _Grades.Add(年龄20_24, "年龄20_24");
            _Grades.Add(年龄25_29, "年龄25_29");
            _Grades.Add(年龄30_34, "年龄30_34");
            _Grades.Add(年龄35_39, "年龄35_39");
            _Grades.Add(年龄40_44, "年龄40_44");
            _Grades.Add(年龄45_49, "年龄45_49");
            _Grades.Add(年龄50_54, "年龄50_54");
            _Grades.Add(年龄55_59, "年龄55_59");
            _Grades.Add(年龄60_64, "年龄60_64");
            _Grades.Add(年龄65_69, "年龄65_69");
        }
        #endregion

        #region 私有变量
        private Dictionary<int, string> _Grades = null;
        #endregion

        #region 公共方法
        /// <summary>
        /// 将年级名称转化成年级编号
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="m_Grade"></param>
        /// <returns></returns>
        public bool TryParse(string grade, out int m_Grade)
        {
            m_Grade = 0;
            foreach (var item in _Grades)
            {
                if (item.Value == grade)
                {
                    m_Grade = item.Key;
                    return true;
                }
            }
            int temp = 0;
            if (int.TryParse(grade, out temp) && _Grades.ContainsKey(temp))
            {
                m_Grade = temp;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 通过年级编号获取年级的名称
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public string GetName(int grade)
        {
            if (_Grades.ContainsKey(grade)) return _Grades[grade];
            return null;
        }
        #endregion
    }
}
