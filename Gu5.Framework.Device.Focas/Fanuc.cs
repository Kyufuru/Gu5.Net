using System;
using System.IO;
using System.Linq;
using System.Net;

using Gu5.Framework.Device.Focas.Models;

namespace Gu5.Framework.Device.Focas
{
    public static class Fanuc
    {
        /// <summary>
        /// Dll 文件检查
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void CheckDll()
        {
            var l = Environment.Is64BitProcess
                ? new[] { "fwlib64.dll", "fwlibe64.dll", "fwlib30i64.dll" }
                : new[] { "fwlib32.dll", "fwlibe1.dll", "fwlib30i.dll" };

            var f = l.FirstOrDefault(x => !File.Exists(x));
            if (f == null) return;
            var msg = $"缺少 FOCAS 依赖文件: {f}";
            throw new InvalidOperationException(msg);
        }

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
            CheckDll();

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
