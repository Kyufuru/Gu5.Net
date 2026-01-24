namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 单选勾选/下拉
    /// </summary>
    /// <typeparam name="T">选项类型</typeparam>
    /// <typeparam name="V">值类型</typeparam>
    public class SelectField<T, V> : FieldBase<V> where T : IOption<V>
    {
        public SelectField() : base()
        {
            Options = [];
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识符</param>
        /// <param name="tx">文本</param>
        /// <param name="opt">选项</param>
        /// <param name="d">值</param>
        public SelectField(string id, string tx, IEnumerable<T> opt, V d): base(id, tx, d) 
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
        public T? Selection { 
            get => Options.FirstOrDefault(x => EqualityComparer<V>.Default.Equals(x.Value, Value)); 
            set => Value = value is null ? default! : value.Value;
        }
    }
}
