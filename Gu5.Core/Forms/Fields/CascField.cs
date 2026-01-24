using System.Collections.Generic;

using Gu5.Core.Trees;

namespace Gu5.Core.Forms.Fields
{
    /// <summary>
    /// 级联/树单选
    /// </summary>
    /// <typeparam name="T">选项类型</typeparam>
    /// <typeparam name="TV">值类型</typeparam>
    public class CascField<T, TV> : SelectField<T, TV> where T : ITree<T>, IOption<TV>
    {
        /// <summary>
        /// 
        /// </summary>
        public CascField() : base() { }

        /// <inheritdoc />
        public CascField(string id, string tx, IEnumerable<T> opt, TV d) : base(id, tx, opt, d) { }
    }
}
