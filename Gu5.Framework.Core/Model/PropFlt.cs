using Gu5.Framework.Core.Enums;

namespace Gu5.Framework.Core.Model
{
    /// <summary>
    /// 属性筛选器
    /// </summary>
    public class PropFlt<T>
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 比较符
        /// </summary>
        public Cmp Cmp { get; set; } = Cmp.EQ;

        /// <summary>
        /// 连接符
        /// </summary>
        public Conj Cnj { get; set; } = Conj.And;

        /// <summary>
        /// 值
        /// </summary>
        public T Value { get; set; } = default;
    }
}
