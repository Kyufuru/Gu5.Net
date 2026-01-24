using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// T/M 模式(复合加工机床专用)
    /// </summary>
    public enum TMMode
    {
        /// <summary>
        /// T 模式
        /// </summary>
        [Description("T 模式")]
        T,

        /// <summary>
        /// M 模式
        /// </summary>
        [Description("M 模式")]
        M,
    }
}
