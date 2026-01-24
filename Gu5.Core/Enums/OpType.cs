using System.ComponentModel;

namespace Gu5.Core.Enums
{
    /// <summary>
    /// 操作符
    /// </summary>
    public enum OpType
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        None,

        /// <summary>
        /// 大于
        /// </summary>
        [Description("大于")]
        GT,

        /// <summary>
        /// 大于等于
        /// </summary>
        [Description("大于等于")]
        GE,

        /// <summary>
        /// 等于
        /// </summary>
        [Description("等于")]
        EQ,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("不等于")]
        NE,

        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("小于等于")]
        LE,

        /// <summary>
        /// 小于
        /// </summary>
        [Description("小于")]
        LT,

        /// <summary>
        /// 包含
        /// </summary>
        [Description("包含")]
        Has,

        /// <summary>
        /// 不包含
        /// </summary>
        [Description("不包含")]
        Excp,

        /// <summary>
        /// 开头是
        /// </summary>
        [Description("开头是")]
        Head,

        /// <summary>
        /// 结尾是
        /// </summary>
        [Description("结尾是")]
        Tail,

        /// <summary>
        /// 通配规则
        /// </summary>
        [Description("通配规则")]
        Reg,
    }
}
