namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 滑动条选择
    /// </summary>
    public class NumsField : FieldBase<decimal[]>
    {
        public NumsField() : base() { }

        /// <inheritdoc/>
        public NumsField(string id, string tx, decimal[] d) : base(id, tx, d) { }
    }
}
