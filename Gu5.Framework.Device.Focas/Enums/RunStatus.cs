using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu5.Framework.Device.Focas.Enums
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
