namespace Gu5.Fanuc.Focas.Models
{
    /// <summary>
    /// 加工信息
    /// </summary>
    public class ProcInfo
    {
        /// <summary>
        /// 班次加工数量
        /// </summary>
        public int BatchQty { get; set; }

        /// <summary>
        /// 总加工数量
        /// </summary>
        public int TotalQty { get; set; }

        /// <summary>
        /// 总通电时长/分钟
        /// </summary>
        public int TotalPowerTime { get; set; }

        /// <summary>
        /// 总运行时长/秒
        /// </summary>
        public int TotalWorkTime { get; set; }

        /// <summary>
        /// 总加工时长
        /// </summary>
        public int TotalProcTime { get; set; }
    }
}
