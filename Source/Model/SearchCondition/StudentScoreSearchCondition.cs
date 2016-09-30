using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HH.TiYu.Cloud.Model.SearchCondition
{
    public class StudentScoreSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        #region 公共属性
        public string StudentID { get; set; }
        public string ProjectID { get; set; }
        public int? PhysicalItem { get; set; }
        public int? Grade { get; set; }
        #endregion
    }
}
