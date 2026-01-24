namespace Gu5.Core.Forms.Fields
{
    /// <summary>
    /// 输入
    /// </summary>
    public class InputField : FieldBase<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public InputField() : base() { }

        /// <inheritdoc />
        public InputField(string id, string tx, string d): base(id, tx, d) { }
    }
}
