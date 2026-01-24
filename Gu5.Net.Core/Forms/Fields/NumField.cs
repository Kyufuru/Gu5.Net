namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 数值输入
    /// </summary>
    public class NumField : FieldBase<decimal>
    {
        public NumField() : base() { }

        /// <inheritdoc />
        public NumField(string id, string tx, decimal d) : base(id, tx, d) { }

    }
}
