using System;

using Gu5.Framework.Core;
using Gu5.Framework.Device.Focas.Enums;

namespace Gu5.Framework.Device.Focas
{
    /// <summary>
    /// 异常
    /// </summary>
    public class FocasException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; } = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="d"></param>
        internal FocasException(short d) 
            : base($"{CodeFrom(d).GetDescription()} ({d})") 
        {
            Code = d;
        }

        /// <summary>
        /// 将内部返回值转换为标准错误
        /// </summary>
        /// <param name="d">内部返回值</param>
        /// <returns></returns>
        private static FanucError CodeFrom(short d)
        {
            try
            {
                switch ((FocasRet)d)
                {
                    case FocasRet.EW_SOCKET:
                    case FocasRet.EW_PROTOCOL:
                        return FanucError.ConnectionFailed;

                    case FocasRet.EW_BUSY:
                        return FanucError.DeviceBusy;

                    case FocasRet.EW_ALARM:
                        return FanucError.Alarm;

                    case FocasRet.EW_STOP:
                    case FocasRet.EW_RESET:
                        return FanucError.NotReady;

                    case FocasRet.EW_NOOPT:
                        return FanucError.NoOption;

                    default:
                        return FanucError.NativeError;
                }

            }
            catch { return FanucError.NativeError; }
        }
    }

}
