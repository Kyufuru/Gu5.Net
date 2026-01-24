using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 急停状态
    /// </summary>
    public enum EmergencyStatus
    {
        [Description("关闭")]
        Off,

        [Description("开启")]
        On,

        [Description("复位")]
        Reset,

        [Description("等待")]
        Wait,
    }
}
