using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 设备错误码
    /// </summary>
    public enum FanucError
    {
        /// <summary>
        /// 连接失败
        /// </summary>
        [Description("连接失败")]
        ConnectionFailed,

        /// <summary>
        /// 设备忙碌
        /// </summary>
        [Description("设备忙碌")]
        DeviceBusy,

        /// <summary>
        /// 设备未运行
        /// </summary>
        [Description("设备未运行")]
        NotReady,

        /// <summary>
        /// 设备正在报警
        /// </summary>
        [Description("设备正在报警")]
        Alarm,

        /// <summary>
        /// 功能未启用
        /// </summary>
        [Description("功能未启用")]
        NoOption,

        /// <summary>
        /// 其他错误
        /// </summary>
        [Description("其他错误")]
        NativeError
    }
}
