using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using LJH.GeneralLibrary;

namespace HH.TiYu.Cloud.WX
{
    public class 中国美院接口Client
    {
        private static string Token { get; set; }

        #region 构造函数
        public 中国美院接口Client()
        {
        }

        public 中国美院接口Client(string url)
        {
            this.BaseUrl = url;
        }
        #endregion

        private readonly string _AppKEY = "8fab4be99a6d079822c20e7128870ea0";

        #region 公共属性
        public string BaseUrl { get; set; }
        #endregion

        #region #region 公共方法
        public 中国美院接口Response 预约(string sid, DateTime dt, string sheme)
        {
            string token = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url = BaseUrl.TrimEnd('/') + "/api/v1/POST/student/token";
                    client.Headers.Add("accept", "application/json");
                    client.Headers.Add("Content-Type", "application/json");
                    var content = JsonConvert.SerializeObject(new { appkey = _AppKEY, role = "student", username = sid, password = "123456", });
                    var retBytes = client.UploadData(url, "POST", ASCIIEncoding.UTF8.GetBytes(content));
                    var ret = JsonConvert.DeserializeObject<中国美院接口Response>(ASCIIEncoding.UTF8.GetString(retBytes));
                    if (ret.Code == 0) token = ret.Description;
                    else return new 中国美院接口Response() { Code = -1, Description = "登录失败" };
                }

                using (WebClient client = new WebClient())
                {
                    string url = BaseUrl.TrimEnd('/') + "/api/v1/auth/POST/studentreservation/";
                    client.Headers.Add("accept", "application/json");
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", string.Format("{0} {1}", "Bearer", token));
                    var fs = (from it in new List<string> { sid }
                              select new
                              {
                                  account = it,
                                  idnumber = it,
                                  testDate = dt.ToString("yyyy-MM-dd HH:mm:ss"),
                                  testscheme = sheme,
                              }).ToList();
                    var content = JsonConvert.SerializeObject(fs);
                    var retBytes = client.UploadData(url, "POST", ASCIIEncoding.UTF8.GetBytes(content));
                    var ret = JsonConvert.DeserializeObject<中国美院接口Response>(ASCIIEncoding.UTF8.GetString(retBytes));
                    return ret;
                }
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                return new 中国美院接口Response() { Code = -1, Description = ex.Message };
            }
        }

        public 中国美院接口获取可预约项目Response 获取可预约项目(string sid)
        {
            string token = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url = BaseUrl.TrimEnd('/') + "/api/v1/POST/student/token";
                    client.Headers.Add("accept", "application/json");
                    client.Headers.Add("Content-Type", "application/json");
                    var content = JsonConvert.SerializeObject(new { appkey = _AppKEY, role = "student", username = sid, password = "123456", });
                    var retBytes = client.UploadData(url, "POST", ASCIIEncoding.UTF8.GetBytes(content));
                    var ret = JsonConvert.DeserializeObject<中国美院接口Response>(ASCIIEncoding.UTF8.GetString(retBytes));
                    if (ret.Code == 0) token = ret.Description;
                    else return new 中国美院接口获取可预约项目Response { Code = -1, Description = "登录失败" };
                }

                using (WebClient client = new WebClient())
                {
                    string url = BaseUrl.TrimEnd('/') + "/api/v1/auth/GET/studentreservation/student/0/";
                    client.Headers.Add("accept", "application/json");
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", string.Format("{0} {1}", "Bearer", token));
                    var retBytes = client.DownloadData(url);
                    var ret = JsonConvert.DeserializeObject<中国美院接口获取可预约项目Response>(ASCIIEncoding.UTF8.GetString(retBytes));
                    return ret;
                }
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                return new 中国美院接口获取可预约项目Response { Code = -1, Description = ex.Message };
            }
        }
        #endregion
    }

    public class 中国美院接口Response
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    public class 中国美院接口获取可预约项目Response : 中国美院接口Response
    {
        [JsonProperty(PropertyName = "entity")]
        public 中国美院接口可预约项目[] Scores { get; set; }
    }

    public class 中国美院接口可预约项目
    {
        [JsonProperty(PropertyName = "testscheme")]
        public string 编号 { get; set; }

        [JsonProperty(PropertyName = "testschemename")]
        public string 项目名称 { get; set; }
    }

    //    0169
    //{"code":"0","description":"WithAuthenticationTokenRequestSchemeOrder0","entity":[{"physicalitem":0,"physicalitemname":"全部","teacher":100,"
    //teachername":"陈某","teacheraccount":"chen","testscheme":7,"testschemename":"全年测试项目","startdate":"2018-04-13 08:42:00",
    //    "enddate":"2019-01-05 08:42:00","maxcount":10000,"address":"广州","memo":"测试"}]}
    ////0

}
