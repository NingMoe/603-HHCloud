using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Handlers;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Results;
using LJH.GeneralLibrary.SoftDog;

namespace HH.TiYu.Cloud.WebApi.Filter
{
    public class HuihaiAuthenticationFilter : FilterAttribute, IAuthenticationFilter, IFilter
    {
        private string _Sheme = "huihai";
        private string _Value = "www.huaxiahuihai.com";
        public async Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
        {
            if (context.Principal.Identity.IsAuthenticated) return;
            var authenHeader = context.Request.Headers.Authorization;
            if (authenHeader != null && authenHeader.Scheme.ToLower() == _Sheme && !string.IsNullOrEmpty(authenHeader.Parameter))
            {
                string temp = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(authenHeader.Parameter));
                temp = new DTEncrypt().DSEncrypt(temp);
                if (!string.IsNullOrEmpty(temp) && temp.ToLower() == _Value)
                {
                    GenericIdentity id = new GenericIdentity(temp.ToLower());
                    context.Principal = new GenericPrincipal(id, null);
                }
                else //解密出错
                {
                    List<AuthenticationHeaderValue> cs = new List<AuthenticationHeaderValue>();
                    cs.Add(new AuthenticationHeaderValue(_Sheme));
                    context.ErrorResult = new UnauthorizedResult(cs, context.Request);
                }
            }
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
        {
            context.Result = new AddHuihaiChallengeResult(_Sheme, context.Result);
            await Task.FromResult(0);
        }

        bool IFilter.AllowMultiple
        {
            get { return false; }
        }
    }

    public class AddHuihaiChallengeResult : IHttpActionResult
    {
        #region 构造函数
        public AddHuihaiChallengeResult(string sheme, IHttpActionResult inner)
        {
            _Sheme = sheme;
            _innerResult = inner;
        }
        #endregion

        #region 私有变量
        private string _Sheme;
        private IHttpActionResult _innerResult;
        #endregion

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await _innerResult.ExecuteAsync(cancellationToken);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                if (response.Headers.WwwAuthenticate.Count(it => it.Scheme == _Sheme) == 0)
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_Sheme));
            }
            return response;
        }
    }
}