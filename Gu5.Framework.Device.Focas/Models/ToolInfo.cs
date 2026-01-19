namespace Gu5.Framework.Device.Focas.Models
{
    /// <summary>
    /// 刀具状态
    /// </summary>
    public class ToolInfo
    {
        /// <summary>
        /// 进给率(实际切削速度) 毫米/分钟
        /// </summary>
        public int FeedRate { get; set; }

        /// <summary>
        /// X 轴坐标
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y 轴坐标
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// X 轴绝对坐标
        /// </summary>
        public double XAbs { get; set; }

        /// <summary>
        /// Y 轴绝对坐标
        /// </summary>
        public double YAbs { get; set; }
    }
}
