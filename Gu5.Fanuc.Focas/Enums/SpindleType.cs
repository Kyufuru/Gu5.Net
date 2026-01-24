using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 主轴类型
    /// </summary>
    public enum SpindleType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = -1,

        /// <summary>
        /// 负载
        /// </summary>
        [Description("负载")]
        Load = 0,

        /// <summary>
        /// 转速
        /// </summary>
        [Description("转速")]
        Speed = 1,
    }
}
