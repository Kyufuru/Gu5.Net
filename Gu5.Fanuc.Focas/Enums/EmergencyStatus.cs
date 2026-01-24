using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 急停状态
    /// </summary>
    public enum EmergencyStatus
    {
        /// <summary>
        /// 关闭
        /// </summary>
        [Description("关闭")]
        Off,

        /// <summary>
        /// 开启
        /// </summary>
        [Description("开启")]
        On,

        /// <summary>
        /// 复位
        /// </summary>
        [Description("复位")]
        Reset,

        /// <summary>
        /// 等待
        /// </summary>
        [Description("等待")]
        Wait,
    }
}
