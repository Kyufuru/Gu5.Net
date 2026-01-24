namespace Gu5.Fanuc.Focas.Models
{
    /// <summary>
    /// 主轴信息
    /// </summary>
    public class SpindleInfo
    {
        /// <summary>
        /// 转速
        /// </summary>
        public double RSpeed { get; set; }

        /// <summary>
        /// 负载
        /// </summary>
        public int Load { get; set; }
    }
}
