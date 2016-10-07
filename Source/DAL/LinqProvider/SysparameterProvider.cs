using System.Linq;
using System.Data.Linq;
using HH.TiYu.Cloud.Model;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace HH.TiYu.DAL.Cloud.LinqProvider
{
    public class SysparameterProvider : ProviderBase<SysparameterInfo,string>
    {
        public SysparameterProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }

        #region 重写模板方法
        protected override SysparameterInfo GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable<SysparameterInfo>().SingleOrDefault(s => s.ID == id);
        }
        #endregion
    }
}