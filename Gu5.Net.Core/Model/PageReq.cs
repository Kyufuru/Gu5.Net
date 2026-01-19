namespace Gu5.Net.Core.Model
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PageReq
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Current { get; set; } = 1;

        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// 总数
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// 当前位置
        /// </summary>
        public int Position => PageSize * (Current - 1);

        /// <summary>
        /// 当前页长
        /// </summary>
        public int CurPageSize => Math.Min(PageSize, (int)Count - Position);

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageTotal => (int)Math.Ceiling((decimal)Count / PageSize);
    }
}
