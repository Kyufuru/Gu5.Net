using System;

namespace Gu5.Core.Models
{
    /// <summary>
    /// 分页
    /// </summary>
    public class Page
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Number { get; set; } = 1;

        /// <summary>
        /// 页长
        /// </summary>
        public int Size { get; set; } = 50;

        /// <summary>
        /// 总数
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int Count => (int)Math.Ceiling((decimal)Total / Size);
    }
}
