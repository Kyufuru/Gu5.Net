using System.Net;

namespace Gu5.Framework.Device.Focas.Internal.X86
{
    internal sealed class Focas1 : BaseFocas1
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="host">主机</param>
        /// <param name="port">端口</param>
        /// <param name="timeout">超时</param>
        public Focas1(IPAddress host, ushort port, int timeout)
            : base(host, port, timeout) { }
    }
}
