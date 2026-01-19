using System.ComponentModel;

namespace Gu5.Framework.Device.Focas.Enums
{
    /// <summary>
    /// 坐标类型
    /// </summary>
    public enum PosType
    {
        [Description("全部")]
        All = -1,

        [Description("绝对坐标")]
        Absolute,

        [Description("机器坐标")]
        Machine,

        [Description("相对坐标")]
        Relative,

        [Description("移动距离")]
        Distance,
    }
}
