using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.TiYu.Cloud.Model
{
    public class PublicWX:LJH.GeneralLibrary.Core.DAL.IEntity <string>
    {
        #region 构造函数
        /// <summary>
        /// 表示一个微信公众号
        /// </summary>
        public PublicWX()
        {
        }
        #endregion

        #region 公共属性
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        public string AppID { get; set; }

        public string AppSecret { get; set; }

        public string Token { get; set; }

        public string EncodingAESKey { get; set; }

        public string DBConnect { get; set; }

        public string AccessToken { get; set; }

        public DateTime? AccessTokenTime { get; set; }

        public DateTime? AccessTokenExpireTime { get; set; }
        #endregion
    }
}
