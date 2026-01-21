using System;
using System.Net;

using Gu5.Framework.Device.Focas.Abstractions;
using Gu5.Framework.Device.Focas.Abstractions.Entities;
using Gu5.Framework.Device.Focas.Enums;

namespace Gu5.Framework.Device.Focas
{
    internal abstract class BaseFocas1 : IFocas1
    {
        private bool _disposed;

        /// <summary>
        /// 主机
        /// </summary>
        protected IPAddress Host { get; }

        /// <summary>
        /// 端口
        /// </summary>
        protected ushort Port { get; }

        /// <summary>
        /// 超时时间
        /// </summary>
        protected int Timeout { get; }

        /// <summary>
        /// 句柄
        /// </summary>
        protected IntPtr Handle { get; set; }

        /// <summary>
        /// 句柄
        /// </summary>
        protected ushort Hdl => (ushort)Handle;

        protected BaseFocas1(IPAddress host, ushort port, int timeout)
        {
            Host = host;
            Port = port;
            Timeout = timeout;
            Handle = IntPtr.Zero;
        }

        /// <summary>
        /// 返回值校验
        /// </summary>
        /// <param name="d"></param>
        /// <exception cref="FocasException"></exception>
        protected static void Valid(short d)
        {
            if (d == (int)FocasRet.EW_OK) return;
            throw new FocasException(d);
        }

        /// <inheritdoc />
        public virtual void Connect()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual void Disconnect()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual StatInfo GetStatInfo()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual ToolInfo GetToolInfo()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual SpindleInfo GetSpindleInfo()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual int ReadParam(short num)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual ProcInfo GetProcInfo()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool d)
        {
            if (_disposed) return;
            else _disposed = d;

            if (Handle != IntPtr.Zero)
            {
                Disconnect();
                Handle = IntPtr.Zero;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        ~BaseFocas1() => Dispose(false);
    }
}
