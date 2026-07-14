using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gu5.Core
{
    /// <summary>
    /// 定时器
    /// </summary>
    public sealed class Interval : IDisposable
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public Interval() { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="f">执行内容</param>
        /// <param name="dly">延迟时间</param>
        public Interval(Func<Task> f, int? dly = null)
        {
            if (dly.HasValue) Delay = dly.Value;
            OnLoop = f;
        }

        private CancellationTokenSource _cts;

        /// <summary>
        /// 轮询间隔, 单位毫秒, 默认10000
        /// </summary>
        public int Delay { get; set; } = 10000;

        /// <summary>
        /// 轮询内容, 默认空操作
        /// </summary>
        public Func<Task> OnLoop { get; set; } = () => Task.CompletedTask;

        /// <summary>
        /// 轮询异常回调
        /// </summary>
        public Action<Exception> OnErr { get; set; }

        /// <summary>
        /// 开始轮询, 已经在轮询中则不执行
        /// </summary>
        public void Start()
        {
            if (_cts != null) return;
            _cts = new CancellationTokenSource();
            _ = Loop(_cts.Token);
        }

        private async Task Loop(CancellationToken tk)
        {
            while (!tk.IsCancellationRequested)
            {
                try
                {
                    // 会话过期时暂停轮询, 重新登录成功后(AuthState.Reset)自动恢复
                    if (AuthState.Expired) { await Task.Delay(1000, tk); continue; }
                    await OnLoop();
                    await Task.Delay(Delay, tk);
                }
                catch (OperationCanceledException) { /* 取消 */ }
                catch (Exception ex)
                {
                    OnErr?.Invoke(ex);
                    await Task.Delay(1000, tk);
                }
            }
        }

        /// <summary>
        /// 停止轮询, 已经停止则不执行
        /// </summary>
        public void Stop()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }

        /// <summary>
        /// 释放资源, 等同于Stop
        /// </summary>
        public void Dispose() => Stop();
    }

}
