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

    public class WXBindingProvider : ProviderBase<WXBinding, string >
    {
        public WXBindingProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写模板方法
        protected override WXBinding GetingItemByID(string  id, DataContext dc)
        {
            WXBinding item = dc.GetTable<WXBinding>().SingleOrDefault(o => o.ID == id);
            return item;
        }

        protected override List<WXBinding> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<WXBinding> ret = dc.GetTable<WXBinding>();
            List<WXBinding> items = ret.ToList();
            return items;
        }
        #endregion
    }
}