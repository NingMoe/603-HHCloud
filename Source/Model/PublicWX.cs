using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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

        #region 公共方法
        /// <summary>
        /// 根据微信签名算法计算签名
        /// </summary>
        public string GetSigniture(string timestamp, string nonce)
        {
            var array = new List<string> { this.Token, timestamp, nonce };
            array.Sort();
            var temp = string.Join(string.Empty, array);
            var data = System.Text.Encoding.ASCII.GetBytes(temp);
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            var bytes = sha.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public PublicWX Clone()
        {
            return this.MemberwiseClone() as PublicWX;
        }
        #endregion
    }
}
