using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HH.TiYu.Cloud.Model.SearchCondition
{
    public class StudentSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string School { get; set; }

        public List<string> StudentIDs { get; set; }

        public bool? WriteCard { get; set; }
    }
}
