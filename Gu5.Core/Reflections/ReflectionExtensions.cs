using System;

namespace Gu5.Core.Reflections
{
    /// <summary>
    /// 反射扩展
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// 动态设置对象属性值（支持枚举）
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="TP">值类型</typeparam>
        /// <param name="this">对象</param>
        /// <param name="n">属性</param>
        /// <param name="d">值</param>
        public static void SetValue<T, TP>(this T @this, string n, TP d) where T : class
        {
            if (@this is null) return;

            var p = @this.GetType().GetProperty(n);
            if (p == null || !p.CanWrite) return;

            try
            {
                if (p.PropertyType.IsEnum && d is string sv)
                    p.SetValue(@this, Enum.Parse(p.PropertyType, sv));
                else p.SetValue(@this, d);
            }
            catch { /* 跳过 */ }
        }
    }
}
