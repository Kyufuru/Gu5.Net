using System.ComponentModel;

namespace Gu5.Framework.Device.Focas.Abstractions.Enums
{
    /// <summary>
    /// 报警状态
    /// </summary>
    public enum AlarmStatus
    {
        [Description("关闭")]
        Off,

        [Description("开启")]
        On,

        [Description("电池低电")]
        BatteryLow,

        [Description("风扇")]
        Fan,

        [Description("电源")]
        Ps,

        [Description("总线")]
        Insulate,

        [Description("编码器")]
        Encoder,

        [Description("PMC")]
        PMC,
    }
}
