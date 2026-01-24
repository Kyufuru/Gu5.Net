using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 坐标类型
    /// </summary>
    public enum PosType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = -1,

        /// <summary>
        /// 绝对坐标
        /// </summary>
        [Description("绝对坐标")]
        Absolute,

        /// <summary>
        /// 机器坐标
        /// </summary>
        [Description("机器坐标")]
        Machine,

        /// <summary>
        /// 相对坐标
        /// </summary>
        [Description("相对坐标")]
        Relative,

        /// <summary>
        /// 移动距离
        /// </summary>
        [Description("移动距离")]
        Distance,
    }
}
