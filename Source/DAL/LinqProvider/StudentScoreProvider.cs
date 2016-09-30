using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.Model.SearchCondition;
using HH.TiYu.DAL;
using System.Data.SQLite;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace HH.TiYu.DAL.Cloud.LinqProvider
{
    public class StudentScoreProvider : ProviderBase<StudentScore, long>
    {
        #region 构造函数
        public StudentScoreProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override StudentScore GetingItemByID(long id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<StudentScore>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<StudentScore> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<StudentScore> ret = dc.GetTable<StudentScore>();
            if (search is StudentScoreSearchCondition)
            {
                StudentScoreSearchCondition con = search as StudentScoreSearchCondition;
                if (!string.IsNullOrEmpty(con.StudentID)) ret = ret.Where(item => item.StudentID == con.StudentID);
                if (!string.IsNullOrEmpty(con.ProjectID)) ret = ret.Where(item => item.ProjectID == con.ProjectID);
                if (con.PhysicalItem != null) ret = ret.Where(item => item.PhysicalItem == con.PhysicalItem.Value);
                if (con.Grade != null) ret = ret.Where(item => item.Grade == con.Grade.Value);
            }
            var temp = ret.ToList();
            return temp;
        }
        #endregion
    }
}

