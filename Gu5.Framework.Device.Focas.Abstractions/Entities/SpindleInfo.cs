namespace Gu5.Framework.Device.Focas.Abstractions.Entities
{
    /// <summary>
    /// 主轴信息
    /// </summary>
    public class SpindleInfo
    {
        /// <summary>
        /// 转速
        /// </summary>
        public double RSpeed { get; set; } = 0;

        /// <summary>
        /// 负载
        /// </summary>
        public int Load { get; set; } = 0;
    }
}
