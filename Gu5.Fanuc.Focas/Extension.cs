using System;
using System.ComponentModel;
using System.Reflection;

namespace Gu5.Fanuc.Focas
{
    internal static class Extension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="this">枚举值</param>
        /// <returns></returns>
        internal static string GetDescription<T>(this T @this) where T : struct, Enum
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
