using System.ComponentModel;

namespace Gu5.Net.Core.Enums
{
    /// <summary>
    /// 操作符
    /// </summary>
    public enum OpType
    {
        [Description("")]
        None,

        [Description("大于")]
        GT,

        [Description("大于等于")]
        GE,

        [Description("等于")]
        EQ,

        [Description("不等于")]
        NE,

        [Description("小于等于")]
        LE,

        [Description("小于")]
        LT,

        [Description("包含")]
        Has,

        [Description("不包含")]
        Excp,

        [Description("开头是")]
        Head,

        [Description("结尾是")]
        Tail,

        [Description("通配规则")]
        Reg,
    }
}
