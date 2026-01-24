using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 报警状态
    /// </summary>
    public enum AlarmStatus
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
        /// 电池低电
        /// </summary>
        [Description("电池低电")]
        BatteryLow,

        /// <summary>
        /// 风扇
        /// </summary>
        [Description("风扇")]
        Fan,

        /// <summary>
        /// 电源
        /// </summary>
        [Description("电源")]
        Ps,

        /// <summary>
        /// 总线
        /// </summary>
        [Description("总线")]
        Insulate,

        /// <summary>
        /// 编码器
        /// </summary>
        [Description("编码器")]
        Encoder,

        /// <summary>
        /// 编码器
        /// </summary>
        [Description("PMC")]
        PMC,
    }
}
