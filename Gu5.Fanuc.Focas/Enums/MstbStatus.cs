using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// MSTB 状态
    /// </summary>
    public enum MstbStatus
    {
        [Description("无")]
        None,

        [Description("M/S/T/B 功能完成")]
        Fin,
    }
}
