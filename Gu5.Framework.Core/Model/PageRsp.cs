using System.Collections.Generic;
using System.Linq;

namespace Gu5.Framework.Core.Model
{
    /// <summary>
    /// 分页响应体
    /// </summary>
    public class PageRsp<T>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public PageRsp() { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="data">数据列表</param>
        /// <param name="tot">总数</param>
        public PageRsp(IEnumerable<T> data, long tot)
        {
            Total = tot;
            Data = data.ToList();
        }

        /// <summary>
        /// 数据总数
        /// </summary>
        public long Total { get; set; } = 0;

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();
    }

}

