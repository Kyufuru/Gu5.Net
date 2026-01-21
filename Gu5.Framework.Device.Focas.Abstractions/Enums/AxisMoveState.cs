using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu5.Framework.Device.Focas.Abstractions.Enums
{
    /// <summary>
    /// 轴移动状态
    /// </summary>
    public enum AxisMoveState
    {
        [Description("无")]
        None,

        [Description("正在移动")]
        Move,

        [Description("暂停/等待")]
        Wait,
    }
}
