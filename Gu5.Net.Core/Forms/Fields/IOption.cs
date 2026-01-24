namespace Gu5.Net.Core.Forms.Fields
{
    /// <summary>
    /// 选项
    /// </summary>
    public interface IOption<V>
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 值
        /// </summary>
        V Value { get; set; }
    }
}
