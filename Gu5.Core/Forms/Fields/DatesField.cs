using System;

namespace Gu5.Core.Forms.Fields
{
    /// <summary>
    /// 日期时间范围选择
    /// </summary>
    public class DatesField : FieldBase<DateTime?[]>
    {
        /// <summary>
        /// 
        /// </summary>
        public DatesField() : base() { }

        /// <inheritdoc />
        public DatesField(string id, string tx, DateTime?[] d) : base(id, tx, d) { }
    }
}
