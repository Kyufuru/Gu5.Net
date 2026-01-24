using System.Collections.Generic;

using Gu5.Core.Trees;

namespace Gu5.Core.Forms.Fields
{
    /// <summary>
    /// 级联/树多选
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    /// <typeparam name="TV">值类型</typeparam>
    public class TreeField<T, TV> : MultiField<T, TV> where T : ITree<T>, IOption<TV>
    {
        /// <summary>
        /// 
        /// </summary>
        public TreeField() : base() { }

        /// <inheritdoc />
        public TreeField(string id, string tx, IEnumerable<T> opt, IEnumerable<TV> d) : base(id, tx, opt, d) { }
    }
}
