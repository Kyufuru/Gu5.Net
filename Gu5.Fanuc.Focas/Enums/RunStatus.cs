using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public enum RunStatus
    {
        [Description("复位/未运行")]
        Reset,

        [Description("停止")]
        Stop,

        [Description("暂停")]
        Hold,

        [Description("运行中")]
        Start,

        [Description("刀具回退/恢复、JOG MDI 运行中")]
        MSTR,
    }
}
