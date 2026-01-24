using System.Diagnostics;

namespace Gu5.Net.Core
{
    /// <summary>
    /// 计时器扩展
    /// </summary>
    public sealed class TimeWatch : IDisposable
    {
        /// <summary>
        /// 计时器
        /// </summary>
        private readonly Stopwatch _sw;

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; private set; }
        
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; private set; }

        /// <summary>
        /// <see cref="Stopwatch.Elapsed"/>
        /// </summary>
        public TimeSpan Elapsed => _sw.Elapsed;

        /// <summary>
        /// <see cref="Stopwatch.ElapsedMilliseconds"/>
        /// </summary>
        public long ElapsedMilliseconds => _sw.ElapsedMilliseconds;

        /// <summary>
        /// <see cref="Stopwatch.ElapsedTicks"/>
        /// </summary>
        public long ElapsedTicks => _sw.ElapsedTicks;

        /// <summary>
        /// <see cref="Stopwatch.IsRunning"/>
        /// </summary>
        public bool IsRunning => _sw.IsRunning;

        /// <summary>
        /// <see cref="Stopwatch.StartNew"/>
        /// </summary>
        public TimeWatch()
        {
            BeginTime = DateTime.Now;
            _sw = Stopwatch.StartNew();
        }

        /// <summary>
        /// <see cref="Stopwatch.Stop"/>
        /// </summary>
        public void Stop()
        {
            if (!_sw.IsRunning) return;

            _sw.Stop();
            EndTime = DateTime.Now;
        }

        /// <summary>
        /// <see cref="Stopwatch.Restart"/>
        /// </summary>
        public void Restart()
        {
            BeginTime = DateTime.Now;
            _sw.Restart();
            EndTime = null;
        }

        /// <summary>
        /// <see cref="Stopwatch.Reset"/>
        /// </summary>
        public void Reset()
        {
            BeginTime = DateTime.Now;
            _sw.Reset();
            EndTime = null;
        }

        /// <summary>
        /// <see cref="Stopwatch.Start"/>
        /// </summary>
        public void Start()
        {
            if (_sw.IsRunning) return;
            BeginTime = DateTime.Now;
            _sw.Start();
        }

        /// <summary>
        /// <see cref="Dispose"/>
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Stop();
        }
    }

}
