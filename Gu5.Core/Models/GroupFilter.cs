using System.Collections.Generic;

using Gu5.Core.Enums;

namespace Gu5.Core.Models
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
        public List<Filter<object>> Filters { get; set; } = 
            new List<Filter<object>>();
    }
}
