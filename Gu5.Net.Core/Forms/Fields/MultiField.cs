namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 多选勾选/下拉
    /// </summary>
    /// <typeparam name="T">选项类型</typeparam>
    /// <typeparam name="V">值类型</typeparam>
    public class MultiField<T, V> : FieldBase<IEnumerable<V>> where T : IOption<V>
    {
        public MultiField() : base()
        {
            Options = [];
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识符</param>
        /// <param name="tx">文本</param>
        /// <param name="opt">选项</param>
        /// <param name="l">值</param>
        public MultiField(string id, string tx, IEnumerable<T> opt, IEnumerable<V> l) : base(id, tx, l)
        {
            Options = opt;
        }

        /// <summary>
        /// 选项
        /// </summary>
        public IEnumerable<T> Options { get; set; }

        /// <summary>
        /// 选择项
        /// </summary>
        public IEnumerable<T> Selection
        {
            get => Options.Where(x => Value.Contains(x.Value));
            set => Value = value.Select(x => x.Value);
        }
    }
}
