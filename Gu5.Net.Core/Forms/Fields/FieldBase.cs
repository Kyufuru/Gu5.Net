using Gu5.Net.Core.Enums;
using Gu5.Net.Core.Models;

namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 基础表单项
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class FieldBase<T> : IField<T>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public FieldBase()
        {
            Id = string.Empty;
            Name = string.Empty;
            Value = default!;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">标识符</param>
        /// <param name="tx">文本</param>
        /// <param name="val">值</param>
        public FieldBase(string id, string tx, T val)
        {
            Id = id;
            Name = tx;
            Value = val;
        }

        /// <inheritdoc />
        public string Id { get; set; }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc/>
        public FieldType Type { get; set; } = FieldType.None;

        /// <inheritdoc />
        public bool Enabled { get; set; } = true;

        /// <inheritdoc />
        public virtual T Value { get; set; }

        /// <inheritdoc />
        public virtual GroupFilter Build() => new()
        {
            Logical = LogiType.And,
            Filters = [new()
            {
                Field = Name,
                Operator = OpType.EQ,
                Value = Value
            }]
        };
    }
}
