using System;
using System.Net;

using Gu5.Fanuc.Focas.Models;

namespace Gu5.Fanuc.Focas
{
    public static class Fanuc
    {
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="host">主机</param>
        /// <param name="port">端口</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        public static IFocas1 Create
        (
            string host = "127.0.0.1", 
            ushort port = 8193,
            int timeout = 5000
        )
        {
            if (!IPAddress.TryParse(host, out var h))
                throw new ArgumentException(nameof(host));

            var rs = Environment.Is64BitProcess
                ? new Internal.X64.Focas1(h, port, timeout)
                : new Internal.X86.Focas1(h, port, timeout)
                as IFocas1;

            rs.Connect();
            return rs;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="d">连接信息</param>
        /// <returns></returns>
        public static IFocas1 Create(ConnInfo d) => 
            Create(d.Host, d.Port, d.Timeout);

    }
}
