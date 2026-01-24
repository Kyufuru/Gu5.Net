using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public enum RunStatus
    {
        /// <summary>
        /// 复位/未运行
        /// </summary>
        [Description("复位/未运行")]
        Reset,

        /// <summary>
        /// 停止
        /// </summary>
        [Description("停止")]
        Stop,

        /// <summary>
        /// 暂停
        /// </summary>
        [Description("暂停")]
        Hold,

        /// <summary>
        /// 运行中
        /// </summary>
        [Description("运行中")]
        Start,

        /// <summary>
        /// 刀具回退/恢复、JOG MDI 运行中
        /// </summary>
        [Description("刀具回退/恢复、JOG MDI 运行中")]
        MSTR,
    }
}
