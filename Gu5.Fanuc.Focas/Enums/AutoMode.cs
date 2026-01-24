using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 自动模式
    /// </summary>
    public enum AutoMode
    {
        /// <summary>
        /// 手动数据输入
        /// </summary>
        [Description("手动数据输入")]
        MDI,

        /// <summary>
        /// 内存自动运行
        /// </summary>
        [Description("内存自动运行")]
        Memory,

        /// <summary>
        /// 未定义/保留
        /// </summary>
        [Description("未定义/保留")]
        None,

        /// <summary>
        /// 编辑模式
        /// </summary>
        [Description("编辑模式")]
        Edit,

        /// <summary>
        /// 手轮模式
        /// </summary>
        [Description("手轮模式")]
        Handle,

        /// <summary>
        /// 点动模式
        /// </summary>
        [Description("点动模式")]
        Jog,

        /// <summary>
        /// 点动示教
        /// </summary>
        [Description("点动示教")]
        JogTeach,

        /// <summary>
        /// 手轮示教
        /// </summary>
        [Description("手轮示教")]
        HandleTeach,

        /// <summary>
        /// 增量进给
        /// </summary>
        [Description("增量进给")]
        IncFeed,

        /// <summary>
        /// 回零
        /// </summary>
        [Description("回零")]
        Reference,

        /// <summary>
        /// 远程
        /// </summary>
        [Description("远程")]
        Remote,
    }
}
