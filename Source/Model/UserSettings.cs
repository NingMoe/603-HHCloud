using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.Model
{
    [Serializable]
    public class UserSettings
    {
        public static UserSettings Current { get; set; }

        #region 公共属性
        public string GetTotalExpression(int grade)
        {
            if (grade >= GradeHelper.一年级 && grade <= GradeHelper.二年级)
                return "[#肺活量] * 0.15 + [#BMI指数] * 0.15 + [#50米跑] * 0.2 + [#坐位体前屈] * 0.3 + [#一分钟跳绳] *0.2 + [加分]";
            if (grade >= GradeHelper.三年级 && grade <= GradeHelper.四年级)
                return "[#肺活量] * 0.15 + [#BMI指数] * 0.15 + [#50米跑] * 0.2 + [#坐位体前屈] * 0.2 + [#一分钟仰卧起坐] * 0.1  + [#一分钟跳绳] * 0.2 + [加分]";
            if (grade >= GradeHelper.五年级 && grade <= GradeHelper.六年级)
                return "[#肺活量] * 0.15 + [#BMI指数] * 0.15 + [#50米跑] * 0.2 + [#坐位体前屈] * 0.1 + [#50米×8往返跑] * 0.1 + [#一分钟仰卧起坐] * 0.2 + [#一分钟跳绳] * 0.1 + [加分]";
            if (grade >= GradeHelper.初一 && grade <= GradeHelper.初三)
                return "[#肺活量] * 0.15 + [#BMI指数] * 0.15 + [#50米跑] * 0.2 + [#立定跳远] * 0.1 + [#坐位体前屈] * 0.1 + ([#800米跑] + [#1000米跑]) * 0.2 + ([#一分钟仰卧起坐] + [#引体向上]) * 0.1 + [加分]";
            if (grade >= GradeHelper.高一 && grade <= GradeHelper.高三)
                return "[#肺活量] * 0.15 + [#BMI指数] * 0.15 + [#50米跑] * 0.2 + [#立定跳远] * 0.1 + [#坐位体前屈] * 0.1 + ([#800米跑] + [#1000米跑]) * 0.2 + ([#一分钟仰卧起坐] + [#引体向上]) * 0.1 + [加分]";
            if (grade >= GradeHelper.大一 && grade <= GradeHelper.大四)
                return "[#肺活量] * 0.15 + [#BMI指数] * 0.15 + [#50米跑] * 0.2 + [#立定跳远] * 0.1 + [#坐位体前屈] * 0.1 + ([#800米跑] + [#1000米跑]) * 0.2 + ([#一分钟仰卧起坐] + [#引体向上]) * 0.1 + [加分]";
            return null;
        }
        #endregion
    }
}
