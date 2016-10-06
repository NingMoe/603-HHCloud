using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HH.TiYu.Cloud.Model;

namespace HH.TiYu.Cloud.WX
{
    /// <summary>
    /// 表示微信客户端
    /// </summary>
    public class WXClient
    {
        /// <summary>
        /// 获取某个公众号的ACCESSKEY
        /// </summary>
        /// <param name="wx"></param>
        /// <returns></returns>
        public async Task<WXAccessKey> GetAccessKeyAsync(PublicWX wx)
        {
            using (var client = HttpClientFactory.Create())
            {
                string uri = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", wx.AppID, wx.AppSecret);
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var ret = await response.Content.ReadAsAsync<WXAccessKey>();
                    return ret;
                }
                return null;
            }
        }
        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="wx"></param>
        /// <returns></returns>
        public async Task<string> GetMenu(PublicWX wx)
        {
            if (string.IsNullOrEmpty(wx.AccessToken)) throw new InvalidOperationException("公众号还没有获取Access_Key");
            using (var client = HttpClientFactory.Create())
            {
                string uri = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", wx.AccessToken);
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var ret = await response.Content.ReadAsStringAsync();
                    return ret;
                }
                return null;
            }
        }

        public async Task<string> SetMenu(PublicWX wx, string menu)
        {
            if (string.IsNullOrEmpty(wx.AccessToken)) throw new InvalidOperationException("公众号还没有获取Access_Key");
            using (var client = HttpClientFactory.Create())
            {
                string uri = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", wx.AccessToken);
                var content = new StringContent(menu);
                HttpResponseMessage response = await client.PostAsync(uri, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var ret = await response.Content.ReadAsStringAsync();
                    return ret;
                }
                return null;
            }
        }
    }

    /// <summary>
    /// 表示获取微信ACCESSKEY返回的对象
    /// </summary>
    public class WXAccessKey
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}