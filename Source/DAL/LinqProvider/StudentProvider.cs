using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.Model.SearchCondition;
using HH.TiYu.DAL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace HH.TiYu.Cloud.DAL.LinqProvider
{
    public class StudentProvider : ProviderBase<Student, string>
    {
        #region 构造函数
        public StudentProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Student GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<Student>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<Student> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<Student> ret = dc.GetTable<Student>();
            if (search is StudentSearchCondition)
            {
                StudentSearchCondition con = search as StudentSearchCondition;
                if (!string.IsNullOrEmpty(con.School)) ret = ret.Where(item => item.FacilityID == con.School);
                if (con.StudentIDs != null && con.StudentIDs.Count > 0) ret = ret.Where(item => con.StudentIDs.Contains(item.ID));
            }
            return ret.ToList();
        }
        #endregion
    }
}
