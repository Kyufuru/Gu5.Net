using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu5.Framework.Device.Focas.Models
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
