using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.DAL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace HH.TiYu.Cloud.DAL.LinqProvider
{

    public class StudentWXProvider : ProviderBase<StudentWX, string>
    {
        public StudentWXProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写模板方法
        protected override StudentWX GetingItemByID(string id, DataContext dc)
        {
            StudentWX item = dc.GetTable<StudentWX>().SingleOrDefault(o => o.ID == id);
            return item;
        }

        protected override List<StudentWX> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<StudentWX> ret = dc.GetTable<StudentWX>();
            List<StudentWX> items = ret.ToList();
            return items;
        }
        #endregion
    }
}