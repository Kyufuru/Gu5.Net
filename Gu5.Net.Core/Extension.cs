using Gu5.Framework.Core;
using Gu5.Framework.Core.Enum;

namespace Gu5.Net.Core
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// 当条件为 true 时执行指定操作
        /// </summary>
        /// <param name="this">条件</param>
        /// <param name="f">操作</param>
        public static bool Then(this bool @this, Action f)
        {
            if (@this) f();
            return @this;
        }

        /// <summary>
        /// 当条件为 false 时执行指定操作
        /// </summary>
        /// <param name="this">条件</param>
        /// <param name="f">操作</param>
        public static bool Else(this bool @this, Action f)
        {
            if (!@this) f();
            return @this;
        }

        /// <summary>
        /// (.NET 10 以下时使用) 
        /// Null 条件分配
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">对象</param>
        /// <param name="f">操作</param>
        /// <returns><paramref name="this"/></returns>
        public static T Also<T>(this T @this, Action<T> f)
        {
            f(@this);
            return @this;
        }

        /// <summary>
        /// Kotlin With
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">对象</param>
        /// <param name="f">设置方法</param>
        /// <returns></returns>
        public static R? With<T, R>(this T? @this, Func<T, R> f)
        {
            if (@this is null) return default;
            return f(@this);
        }

        public static T? Find<T>(this IEnumerable<T> @this) =>
            @this.FirstOrDefault();

        public static T? Find<T>(this IEnumerable<T> @this, Func<T, bool> pred) =>
            @this.FirstOrDefault(pred);

        public static T? Find<T>(this IEnumerable<T> @this, Func<T, bool> pred, T def) =>
            @this.FirstOrDefault(pred, def);

        public static void Deconstruct<T>(this T[] @this,
            out T? e1, out T? e2)
        {
            e1 = @this.ElementAtOrDefault(0);
            e2 = @this.ElementAtOrDefault(1);
        }

        public static void Deconstruct<T>(this T[] @this,
            out T? e1, out T? e2, out T? e3)
        {
            e1 = @this.ElementAtOrDefault(0);
            e2 = @this.ElementAtOrDefault(1);
            e3 = @this.ElementAtOrDefault(2);
        }

        public static void Deconstruct<T>(this T[] @this,
            out T? e1, out T? e2, out T? e3, out T? e4)
        {
            e1 = @this.ElementAtOrDefault(0);
            e2 = @this.ElementAtOrDefault(1);
            e3 = @this.ElementAtOrDefault(2);
            e4 = @this.ElementAtOrDefault(3);
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T> f)
        {
            foreach (var x in @this) f(x);
            return @this;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T, int> f)
        {
            if (f is null) return @this;

            int i = 0;
            @this.ForEach(x => f(x, i++));

            return @this;
        }

        /// <summary>
        /// 随机
        /// </summary>
        private static readonly ThreadLocal<Random> _rnd =
            new(() => new(Guid.NewGuid().GetHashCode()));

        /// <summary>
        /// 随机采样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T? Sample<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0) return default;
            return list[_rnd.Value!.Next(list.Count)];
        }

        /// <summary>
        /// 安全范围索引
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">列表</param>
        /// <param name="i">索引</param>
        /// <returns></returns>
        public static List<T> Range<T>(this IList<T> @this, int i, int cnt)
        {
            i = Math.Clamp(i, 0, @this.Count - 1);
            cnt = Math.Clamp(cnt, 0, @this.Count - i);
            return @this.ToList().GetRange(i, cnt);
        }

        /// <summary>
        /// 安全索引
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">列表</param>
        /// <param name="i">索引</param>
        /// <returns></returns>
        public static T? At<T>(this IList<T> @this, int i)
        {
            if (@this.Count < 1) return default;
            i = Math.Clamp(i, 0, @this.Count - 1);
            return @this[i];
        }

        /// <summary>
        /// 安全索引
        /// </summary>
        /// <param name="this">列表</param>
        /// <param name="i">索引</param>
        /// <returns></returns>
        public static T? At<T>(this IEnumerable<T> @this, int i) =>
            @this.ElementAtOrDefault(i);

        /// <summary>
        /// 取模索引
        /// </summary>
        public static T Mod<T>(this IList<T> @this, int i)
        {
            int len = @this.Count;
            if (len == 0) throw new ZException("越界访问");
            return @this[((i % len) + len) % len];
        }

        /// <summary>
        /// 时间轴
        /// </summary>
        /// <param name="t1">开始时间</param>
        /// <param name="t2">结束时间</param>
        /// <param name="ut">时间单位</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns><![CDATA[List<DateTime>]]></returns>
        public static List<DateTime> RangeFrom(DateTime t1, DateTime t2, DtUnit ut = DtUnit.Minute)
        {
            if (ut != DtUnit.Minute) throw new NotImplementedException();

            var tm = new DateTime
            (
                t1.Year, t1.Month, t1.Day,
                t1.Hour, t1.Minute, 0,
                t1.Kind
            );

            var rs = new List<DateTime>();
            for (var i = tm; i <= t2; i = i.AddMinutes(1)) rs.Add(i);
            return rs;
        }

        /// <summary>
        /// 重采样
        /// </summary>
        /// <typeparam name="T"/>
        /// <param name="this">The this.</param>
        /// <param name="f">The F.</param>
        /// <param name="ut">The ut.</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns><![CDATA[Dictionary<DateTime, T>]]></returns>
        public static Dictionary<DateTime, T> Resample<T>(this IEnumerable<T> @this,
            Func<T, DateTime> f, DtUnit ut = DtUnit.Minute)
        {
            if (ut != DtUnit.Minute) throw new NotImplementedException();

            return @this.GroupBy(x => new DateTime(
                f(x).Year, f(x).Month, f(x).Day,
                f(x).Hour, f(x).Minute, 0, f(x).Kind
            )).ToDictionary(
                g => g.Key,
                g => g.OrderBy(x => f(x)
            ).Last());
        }

        /// <summary>
        /// Pandas FFill
        /// </summary>
        /// <typeparam name="V">值类型</typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="l"></param>
        /// <param name="this"></param>
        /// <param name="lim"></param>
        /// <returns></returns>
        public static List<V?> FFill<V, K>(this IReadOnlyDictionary<K, V> @this, 
            IEnumerable<K> l, int lim = 1)
        {
            var cnt = 0;
            var ever = false;
            var last = default(V);

            return [.. l.Select(x =>
            {
                if (@this.TryGetValue(x, out var v))
                {
                    last = v;
                    ever = true;
                    cnt = 0;
                    return last;
                }

                if (ever && cnt < lim)
                {
                    cnt++;
                    return last;
                }

                return default;
            })];
        }
    }
}
