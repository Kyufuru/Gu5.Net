using System.ComponentModel;

namespace Gu5.Fanuc.Focas.Enums
{
    /// <summary>
    /// 程序编辑状态
    /// </summary>
    public enum ProgramEditStatus
    {
        /// <summary>
        /// 未编辑
        /// </summary>
        [Description("未编辑")]
        None,

        /// <summary>
        /// 编辑中
        /// </summary>
        [Description("编辑中")]
        Edit,
    }
}
