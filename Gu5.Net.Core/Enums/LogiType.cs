using System.ComponentModel;

namespace Gu5.Net.Core.Enums
{
    /// <summary>
    /// 逻辑符
    /// </summary>
    public enum LogiType
    {
        [Description("并且")]
        And,

        [Description("或者")]
        Or,

        [Description("并且不是")]
        AndNot,

        [Description("或者不是")]
        OrNot,
    }
}
