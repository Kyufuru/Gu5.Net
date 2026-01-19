using System.ComponentModel;

namespace Gu5.Framework.Device.Focas.Enums
{
    /// <summary>
    /// 自动模式
    /// </summary>
    public enum AutoMode
    {
        [Description("手动数据输入")]
        MDI,

        [Description("内存自动运行")]
        Memory,

        [Description("未定义/保留")]
        None,

        [Description("编辑模式")]
        Edit,

        [Description("手轮模式")]
        Handle,

        [Description("点动模式")]
        Jog,

        [Description("点动示教")]
        JogTeach,

        [Description("手轮示教")]
        HandleTeach,

        [Description("增量进给")]
        IncFeed,

        [Description("回零")]
        Reference,

        [Description("远程")]
        Remote,
    }
}
