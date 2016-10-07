using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using LJH.GeneralLibrary.Core.DAL;
using HH.TiYu.Cloud.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class SystemParameterBLL : BLLBase<string, SysparameterInfo>
    {
        #region 构造函数
        public SystemParameterBLL(string repUri)
            : base(repUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public CommandResult Save(SysparameterInfo parameter)
        {
            SysparameterInfo original = ProviderFactory.Create<IProvider<SysparameterInfo, string>>(RepoUri).GetByID(parameter.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IProvider<SysparameterInfo, string>>(RepoUri).Update(parameter, original);
            }
            else
            {
                return ProviderFactory.Create<IProvider<SysparameterInfo, string>>(RepoUri).Insert(parameter);
            }
        }

        public override CommandResult Add(SysparameterInfo info)
        {
            return Save(info);
        }
        #endregion
    }
}
