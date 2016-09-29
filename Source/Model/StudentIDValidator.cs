using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.Model
{
    public class StudentIDValidator
    {
        public bool IsValid(string studentID)
        {
            if (string.IsNullOrEmpty(studentID)) return false;
            var reg = new Regex("^[A-Za-z0-9]+$");
            return reg.IsMatch(studentID);
        }
    }
}
