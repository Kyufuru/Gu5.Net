using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gu5.Framework.Core
{
    public sealed class Interval : IDisposable
    {
        public Interval() { }
        public Interval(Func<Task> f, int? dly = null)
        {
            if (dly.HasValue) Delay = dly.Value;
            OnLoop = f;
        }

        private CancellationTokenSource _cts;
        public int Delay { get; set; } = 10000;
        public Func<Task> OnLoop { get; set; } = () => Task.CompletedTask;
        public Action<Exception> OnErr { get; set; }

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

        public void Stop()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }

        public void Dispose() => Stop();
    }

}
