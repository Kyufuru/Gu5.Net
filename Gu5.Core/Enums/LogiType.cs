using System.ComponentModel;

namespace Gu5.Core.Enums
{
    /// <summary>
    /// 逻辑符
    /// </summary>
    public enum LogiType
    {
        /// <summary>
        /// 且
        /// </summary>
        [Description("并且")]
        And,

        /// <summary>
        /// 或
        /// </summary>
        [Description("或者")]
        Or,

        /// <summary>
        /// 且非
        /// </summary>
        [Description("并且不是")]
        AndNot,

        /// <summary>
        /// 或非
        /// </summary>
        [Description("或者不是")]
        OrNot,
    }
}
