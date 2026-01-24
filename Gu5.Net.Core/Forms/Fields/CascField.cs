using Gu5.Net.Core.Trees;

namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 级联/树单选
    /// </summary>
    /// <typeparam name="T">选项类型</typeparam>
    /// <typeparam name="V">值类型</typeparam>
    public class CascField<T, V> : SelectField<T, V> where T : ITree<T>, IOption<V>
    {
        public CascField() : base() { }

        /// <inheritdoc />
        public CascField(string id, string tx, IEnumerable<T> opt, V d) : base(id, tx, opt, d) { }
    }
}
