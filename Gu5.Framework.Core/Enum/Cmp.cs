using System.ComponentModel;

namespace Gu5.Framework.Core.Enum
{
    /// <summary>
    /// 数值比较
    /// </summary>
    public enum Cmp
    {
        /// <summary>
        /// 大于
        /// </summary>
        [Description("大于")]
        GT = 0,

        /// <summary>
        /// 大于等于
        /// </summary>
        [Description("大于等于")]
        GE = 1,

        /// <summary>
        /// 等于
        /// </summary>
        [Description("等于")]
        EQ = 2,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("不等于")]
        NE = 3,

        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("小于等于")]
        LE = 4,

        /// <summary>
        /// 小于
        /// </summary>
        [Description("小于")]
        LT = 5,

        /// <summary>
        /// 包含
        /// </summary>
        [Description("包含")]
        Has = 6,

        /// <summary>
        /// 不包含
        /// </summary>
        [Description("不包含")]
        Excp = 7,

        /// <summary>
        /// 开头是
        /// </summary>
        [Description("开头是")]
        Head = 8,

        /// <summary>
        /// 结尾是
        /// </summary>
        [Description("结尾是")]
        Tail = 9,

        /// <summary>
        /// 通配规则
        /// </summary>
        [Description("通配规则")]
        Reg = 10,
    }
}
