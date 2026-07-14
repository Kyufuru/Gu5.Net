using System.Collections.Generic;

namespace Gu5.Core.Http
{
    /// <summary>
    /// 请求头
    /// </summary>
    public class HttpHead
    {
        /// <summary>
        /// 基地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 请求头
        /// </summary>
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="u">地址</param>
        /// <param name="tk">令牌</param>
        public HttpHead(string u, string tk = null)
        {
            Url = u;
            Token = tk;
        }
    }
}
