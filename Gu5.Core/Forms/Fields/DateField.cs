using System;

namespace Gu5.Core.Forms.Fields
{
    /// <summary>
    /// 日期时间选择
    /// </summary>
    public class DateField : FieldBase<DateTime?>
    {
        /// <summary>
        /// 
        /// </summary>
        public DateField() : base() { }

        /// <inheritdoc />
        public DateField(string id, string tx, DateTime? d) : base(id, tx, d) { }
    }
}
