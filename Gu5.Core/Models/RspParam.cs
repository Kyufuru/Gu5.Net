using System.Collections.Generic;

namespace Gu5.Core.Models
{
    /// <summary>
    /// 分页响应体
    /// </summary>
    public class RspParam<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public RspParam() { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="l">数据</param>
        /// <param name="p">分页</param>
        public RspParam(List<T> l, Page p)
        {
            Page = p;
            Data = l;
        }

        /// <summary>
        /// 数据总数
        /// </summary>
        public Page Page { get; set; } = new Page();

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();
    }

}

