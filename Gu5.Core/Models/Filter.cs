using Gu5.Core.Enums;

namespace Gu5.Core.Models
{
    /// <summary>
    /// 筛选器
    /// </summary>
    public class Filter<T>
    {
        /// <summary>
        /// 项
        /// </summary>
        public string Field { get; set; } = string.Empty;

        /// <summary>
        /// 操作
        /// </summary>
        public OpType Operator { get; set; } = OpType.None;

        /// <summary>
        /// 值
        /// </summary>
        public T Value { get; set; }
    }
}
