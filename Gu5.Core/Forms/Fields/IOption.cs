namespace Gu5.Core.Forms.Fields
{
    /// <summary>
    /// 选项
    /// </summary>
    public interface IOption<TV>
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 值
        /// </summary>
        TV Value { get; set; }
    }
}
