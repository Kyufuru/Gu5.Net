namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 日期时间选择
    /// </summary>
    public class DateField : FieldBase<DateTime?>
    {
        public DateField() : base() { }

        /// <inheritdoc />
        public DateField(string id, string tx, DateTime? d) : base(id, tx, d) { }
    }
}
