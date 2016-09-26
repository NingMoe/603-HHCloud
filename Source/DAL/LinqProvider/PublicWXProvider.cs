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

    public class PublicWXProvider : ProviderBase<PublicWX, string>
    {
        public PublicWXProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写模板方法
        protected override PublicWX GetingItemByID(string id, DataContext dc)
        {
            PublicWX item = dc.GetTable<PublicWX>().SingleOrDefault(o => o.ID == id);
            return item;
        }

        protected override List<PublicWX> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<PublicWX> ret = dc.GetTable<PublicWX>();
            List<PublicWX> items = ret.ToList();
            return items;
        }
        #endregion
    }
}
