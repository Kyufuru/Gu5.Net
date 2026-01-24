namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 输入
    /// </summary>
    public class InputField : FieldBase<string>
    {
        public InputField() : base() { }

        /// <inheritdoc />
        public InputField(string id, string tx, string d): base(id, tx, d) { }
    }
}
