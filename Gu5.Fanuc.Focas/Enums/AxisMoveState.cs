using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 轴移动状态
    /// </summary>
    public enum AxisMoveState
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None,

        /// <summary>
        /// 正在移动
        /// </summary>
        [Description("正在移动")]
        Move,

        /// <summary>
        /// 暂停/等待
        /// </summary>
        [Description("暂停/等待")]
        Wait,
    }
}
