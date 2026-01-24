using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;

using Gu5.Core;

namespace Gu5.Core
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
        /// <typeparam name="TR">返回类型</typeparam>
        /// <param name="this">对象</param>
        /// <param name="f">设置方法</param>
        /// <returns></returns>
        public static TR With<T, TR>(this T @this, Func<T, TR> f)
        {
            if (@this == null) return default;
            return f(@this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T Find<T>(this IEnumerable<T> @this) =>
            @this.FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public static T Find<T>(this IEnumerable<T> @this, Func<T, bool> pred) =>
            @this.FirstOrDefault(pred);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="pred"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T Find<T>(this IEnumerable<T> @this, Func<T, bool> pred, T def) =>
            @this.Find(pred).Also(x => (x == null).Then(() => x = def));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        public static void Deconstruct<T>(this T[] @this,
            out T e1, out T e2)
        {
            e1 = @this.ElementAtOrDefault(0);
            e2 = @this.ElementAtOrDefault(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <param name="e3"></param>
        public static void Deconstruct<T>(this T[] @this,
            out T e1, out T e2, out T e3)
        {
            e1 = @this.ElementAtOrDefault(0);
            e2 = @this.ElementAtOrDefault(1);
            e3 = @this.ElementAtOrDefault(2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <param name="e3"></param>
        /// <param name="e4"></param>
        public static void Deconstruct<T>(this T[] @this,
            out T e1, out T e2, out T e3, out T e4)
        {
            e1 = @this.ElementAtOrDefault(0);
            e2 = @this.ElementAtOrDefault(1);
            e3 = @this.ElementAtOrDefault(2);
            e4 = @this.ElementAtOrDefault(3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T> f)
        {
            foreach (var x in @this) f(x);
            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="f"></param>
        /// <returns></returns>
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
            new ThreadLocal<Random>(() => 
                new Random(Guid.NewGuid().GetHashCode()));

        /// <summary>
        /// 随机采样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Sample<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0) return default;
            return list[_rnd.Value.Next(list.Count)];
        }

        /// <summary>
        /// 上下限截取
        /// </summary>
        /// <param name="this">值</param>
        /// <param name="min">下限</param>
        /// <param name="max">上限</param>
        /// <returns></returns>
        public static int Clamp(this int @this, int min, int max) =>
            Math.Max(Math.Min(@this, max), min);

        /// <summary>
        /// 安全范围索引
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">列表</param>
        /// <param name="i">索引</param>
        /// <param name="cnt">长度</param>
        /// <returns></returns>
        public static List<T> Range<T>(this IList<T> @this, int i, int cnt)
        {
            i = i.Clamp(0, @this.Count - 1);
            cnt = cnt.Clamp(0, @this.Count - i);
            return @this.ToList().GetRange(i, cnt);
        }

        /// <summary>
        /// 安全索引
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="this">列表</param>
        /// <param name="i">索引</param>
        /// <returns></returns>
        public static T At<T>(this IList<T> @this, int i)
        {
            if (@this.Count < 1) return default;
            i = i.Clamp(0, @this.Count - 1);
            return @this[i];
        }

        /// <summary>
        /// 安全索引
        /// </summary>
        /// <param name="this">列表</param>
        /// <param name="i">索引</param>
        /// <returns></returns>
        public static T At<T>(this IEnumerable<T> @this, int i) =>
            @this.ElementAtOrDefault(i);

        /// <summary>
        /// 取模索引
        /// </summary>
        public static T Mod<T>(this IList<T> @this, int i)
        {
            int len = @this.Count;
            if (len == 0) throw new GException("越界访问");
            return @this[((i % len) + len) % len];
        }

        /// <summary>
        /// 时间轴
        /// </summary>
        /// <param name="t1">开始时间</param>
        /// <param name="t2">结束时间</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns><![CDATA[List<DateTime>]]></returns>
        public static List<DateTime> RangeFrom(DateTime t1, DateTime t2)
        {
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
        /// <param name="this">列表</param>
        /// <param name="f">时间字段</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns><![CDATA[Dictionary<DateTime, T>]]></returns>
        public static Dictionary<DateTime, T> Resample<T>(
            this IEnumerable<T> @this, Func<T, DateTime> f)
        {
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
        /// <typeparam name="TV">值类型</typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <param name="l"></param>
        /// <param name="this"></param>
        /// <param name="lim"></param>
        /// <returns></returns>
        public static List<TV> FFill<TV, TK>(this IReadOnlyDictionary<TK, TV> @this, 
            IEnumerable<TK> l, int lim = 1)
        {
            var cnt = 0;
            var ever = false;
            var last = default(TV);

            return l.Select(x =>
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
            }).ToList();
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="this">枚举值</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T @this) where T : struct, Enum
        {
            var t = typeof(T);
            var n = Enum.GetName(t, @this);
            if (n is null) return $"{@this}";

            var fd = t.GetField(n, BindingFlags.Public | BindingFlags.Static);
            if (fd == null) return n;

            var attr = fd.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? n;
        }
    }
}
