using Gu5.Net.Core.Enums;

namespace Gu5.Net.Core.Models
{
    /// <summary>
    /// 筛选器组
    /// </summary>
    public class GroupFilter
    {
        /// <summary>
        /// 逻辑符
        /// </summary>
        public LogiType Logical { get; set; } = LogiType.And;

        /// <summary>
        /// 筛选项
        /// </summary>
        public List<Filter<object>> Filters { get; set; } = [];
    }
}
