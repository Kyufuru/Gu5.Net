using System.Net;

namespace Gu5.Framework.Device.Focas.Abstractions.Entities
{
    /// <summary>
    /// 连接信息
    /// </summary>
    public class ConnInfo
    {
        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; } = $"{IPAddress.Loopback}";

        /// <summary>
        /// 端口
        /// </summary>
        public ushort Port { get; set; } = 8193;

        /// <summary>
        /// 超时
        /// </summary>
        public int Timeout { get; set; } = 5000;

    }
}
