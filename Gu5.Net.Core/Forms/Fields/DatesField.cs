namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 日期时间范围选择
    /// </summary>
    /// <param name="id">标识符</param>
    /// <param name="tx">文本</param>
    /// <param name="d">值</param>
    public class DatesField(string id, string tx, DateTime?[] d) : FieldBase<DateTime?[]>(id, tx, d)
    {
    }
}
