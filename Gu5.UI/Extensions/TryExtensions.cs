using Gu5.Core;

namespace Gu5.UI.Extensions
{
    public static class TryExtensions
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="act"></param>
        /// <param name="onFin"></param>
        /// <param name="ok"></param>
        /// <returns></returns>
        public static async Task TryAsync(this Control @this,
            Func<Task> act, Action? onFin = null, bool ok = false)
        {
            try
            {
                await act();
                if (ok) @this.ShowOkMsg();
            }
            catch (Exception ex)
            {
                @this.ShowErrMsg(ex);
            }
            finally { onFin?.Invoke(); }
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="act"></param>
        /// <param name="onFin"></param>
        /// <param name="ok"></param>
        /// <returns></returns>
        public static async Task TryAsync(this UserControl @this,
            Func<Task> act, Action? onFin = null, bool ok = false) =>
            (@this as Control)?.TryAsync(act, onFin, ok);

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="act"></param>
        public static void Try(this Control @this,
            Action act, Action? onFin = null, bool ok = false)
        {
            try
            {
                act();
                if (ok) @this.ShowOkMsg();
            }
            catch (Exception ex)
            {
                @this.ShowErrMsg(ex.Message);
            }
            finally { onFin?.Invoke(); }
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="act"></param>
        /// <param name="onFin"></param>
        /// <param name="ok"></param>
        public static void Try(this UserControl @this,
            Action act, Action? onFin = null, bool ok = false) =>
            (@this as Control)?.Try(act, onFin, ok);

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="act"></param>
        public static T? Try<T>(this Control @this,
            Func<T> act, Action? onFin = null, bool ok = false)
        {
            try
            {
                var rs = act();
                if (ok) @this.ShowOkMsg();
                return rs;
            }
            catch (Exception ex)
            {
                @this.ShowErrMsg(ex.Message);
                return default;
            }
            finally { onFin?.Invoke(); }
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="act"></param>
        /// <param name="onFin"></param>
        /// <param name="ok"></param>
        public static T? Try<T>(this UserControl @this,
            Func<T> act, Action? onFin = null, bool ok = false) =>
            (@this as Control).With(x => x.Try(act, onFin, ok));
    }
}
