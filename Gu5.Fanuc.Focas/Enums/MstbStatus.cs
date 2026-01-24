using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// MSTB 状态
    /// </summary>
    public enum MstbStatus
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None,

        /// <summary>
        /// M/S/T/B 功能完成
        /// </summary>
        [Description("M/S/T/B 功能完成")]
        Fin,
    }
}
