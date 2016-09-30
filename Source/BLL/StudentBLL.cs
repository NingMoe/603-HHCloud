using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class StudentBLL : BLLBase<string, Student>
    {
        #region 构造函数
        public StudentBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion
    }
}