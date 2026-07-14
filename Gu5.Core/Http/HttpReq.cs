using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Gu5.Core.Http
{
    /// <summary>
    /// HTTP 请求
    /// </summary>
    public class HttpReq
    {
        /// <summary>
        /// 请求头
        /// </summary>
        public HttpHead Head { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="hd">请求头</param>
        public HttpReq(HttpHead hd)
        {
            Head = hd;
        }

        private async Task<T> TryAsync<T>(string u, Func<IFlurlRequest, Task<T>> f)
        {
            try
            {
                if (Head is null) throw new GMissException("请求头");
                return await f(new Url($"{Head.Url}/{u}")
                    .WithOAuthBearerToken(Head.Token)
                    .WithHeaders(Head.Headers));
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == 401)
                {
                    AuthState.NotifyExpired();
                    throw new GAuthException();
                }
                var msg = await OnFail(ex);
                throw new GException(msg);
            }
        }

        private static async Task<string> OnFail(FlurlHttpException ex)
        {
            var msg = await ex.GetResponseStringAsync();
            if (string.IsNullOrEmpty(msg)) msg = ex.Message;
            return Regex.Unescape(msg);
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="u"></param>
        /// <returns>字符串</returns>
        public virtual Task<string> GetAsync(string u) => 
            TryAsync(u, x => x.GetStringAsync());

        /// <summary>
        /// GET
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="u">URL</param>
        /// <returns>对象</returns>
        public virtual Task<T> GetAsync<T>(string u) => 
            TryAsync(u, x => x.GetJsonAsync<T>());

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="u">URL</param>
        /// <param name="d">数据</param>
        /// <returns>字符串</returns>
        public virtual Task<string> PostAsync(string u, object d = null) =>
            TryAsync(u, x => x.PostJsonAsync(d).ReceiveString());
        /// <summary>
        /// POST
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="u">URL</param>
        /// <param name="d">数据</param>
        /// <returns>对象</returns>
        public virtual Task<T> PostAsync<T>(string u, object d = null) =>
            TryAsync(u, x => x.PostJsonAsync(d).ReceiveJson<T>());
        /// <summary>
        /// 发送 POST 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="u">URL</param>
        /// <param name="d">数据</param>
        /// <returns>对象</returns>
        public virtual Task<T> PostAsync<T>(string u, T d) =>
            TryAsync(u, x => x.PostJsonAsync(d).ReceiveJson<T>());
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="u">URL</param>
        /// <param name="d">数据</param>
        /// <returns>传输流</returns>
        public virtual Task<Stream> DownAsync(string u, object d) =>
            TryAsync(u, x => x.PostJsonAsync(d).ReceiveStream());

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="u">URL</param>
        /// <returns>传输流</returns>
        public virtual Task<Stream> DownAsync(string u) =>
            TryAsync(u, x => x.GetAsync().ReceiveStream());

        /// <summary>
        /// 上传
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="u">URL</param>
        /// <param name="f">上传工具回调</param>
        /// <returns></returns>
        public virtual Task<T> UpAsync<T>(string u, Action<CapturedMultipartContent> f) =>
            TryAsync(u, x => x.PostMultipartAsync(f).ReceiveJson<T>());
    }
}
