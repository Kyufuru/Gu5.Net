using System;
using System.Threading;

namespace Gu5.Core
{
    /// <summary>
    /// 认证状态: 集中标记会话是否过期, 桥接"请求层"(HttpReq)与"定时器层"(Interval)。
    /// </summary>
    public static class AuthState
    {
        private static int _expired; // 0=正常, 1=已过期

        /// <summary>
        /// 会话是否已过期
        /// </summary>
        public static bool Expired => Volatile.Read(ref _expired) == 1;

        /// <summary>
        /// 会话过期时触发(仅首次 false→true), 用于驱动重新登录
        /// </summary>
        public static event Action OnExpired;

        /// <summary>
        /// 标记会话过期; 仅首次状态翻转时触发 <see cref="OnExpired"/>
        /// </summary>
        public static void NotifyExpired()
        {
            if (Interlocked.Exchange(ref _expired, 1) == 0)
                OnExpired?.Invoke();
        }

        /// <summary>
        /// 重置(重新登录成功后调用), 恢复轮询
        /// </summary>
        public static void Reset() => Volatile.Write(ref _expired, 0);
    }
}
