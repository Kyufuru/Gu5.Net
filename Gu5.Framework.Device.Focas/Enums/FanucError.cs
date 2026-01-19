using System.ComponentModel;

namespace Gu5.Framework.Device.Focas.Enums
{
    /// <summary>
    /// 设备错误码
    /// </summary>
    public enum FanucError
    {
        [Description("连接失败")]
        ConnectionFailed,

        [Description("设备忙碌")]
        DeviceBusy,

        [Description("设备未运行")]
        NotReady,

        [Description("设备正在报警")]
        Alarm,

        [Description("功能未启用")]
        NoOption,

        [Description("其他错误")]
        NativeError
    }
}
