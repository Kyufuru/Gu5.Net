using System.ComponentModel;

namespace Gu5.Framework.Device.Focas.Abstractions.Enums
{
    public enum SpindleType
    {
        [Description("全部")]
        All = -1,

        [Description("负载")]
        Load = 0,

        [Description("转速")]
        Speed = 1,
    }
}
