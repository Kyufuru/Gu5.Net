using Gu5.Net.Core.Trees;

namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 级联/树多选
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <typeparam name="V">值类型</typeparam>
    public class TreeField<T, V> : MultiField<T, V> where T : ITree<T>, IOption<V>
    {
        public TreeField() : base() { }

        /// <inheritdoc />
        public TreeField(string id, string tx, IEnumerable<T> opt, IEnumerable<V> d) : base(id, tx, opt, d) { }
    }
}
