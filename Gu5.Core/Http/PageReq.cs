using System;

namespace Gu5.Core.Http
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PageReq
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// 当前页长
        /// </summary>
        public int CurPageSize => Math.Min(PageSize,
            (int)Count - (Current - 1) * PageSize);

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageTotal => (int)Math.Ceiling((double)Count / PageSize);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="cur">页码</param>
        /// <param name="sz">页长</param>
        public PageReq(int cur = 1, int sz = 50)
        {
            Current = cur;
            PageSize = sz;
        }
    }
}
