using Gu5.Core.Abstracts;

namespace Gu5.FreeSql.Abstracts
{
    /// <summary>
    /// 树
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <typeparam name="TI">关联类型</typeparam>
    public interface ITreeEntity<T, TI> : ITree<T>
    {
        /// <summary>
        /// 上级标识
        /// </summary>
        TI ParentId { get; set; }
    }
}
