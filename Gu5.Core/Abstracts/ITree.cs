using System.Collections.Generic;

namespace Gu5.Core.Abstracts
{
    /// <summary>
    /// 基础树表
    /// </summary>
    public interface ITree<T>
    {
        /// <summary>
        /// 上级
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        /// 下级别名
        /// </summary>
        IEnumerable<T> Children { get; set; }
    }
}
