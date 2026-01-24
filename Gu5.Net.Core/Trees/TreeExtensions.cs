namespace Gu5.Net.Core.Trees
{
    /// <summary>
    /// 树扩展
    /// </summary>
    public static class TreeExtensions
    {
        public static void ForEach<T>(this T @this, Action<T> f) where T : ITree<T>
        {
            foreach (var x in @this.Children)
            {
                f(x);
                x.ForEach(f);
            }
        }

        public static List<T> Where<T>(this T @this, Func<T, bool> f) where T : ITree<T>
        {
            var rs = new List<T>();
            foreach (var x in @this.Children)
            {
                var sub = Where(x, f);
                if (sub.Count == 0) continue;
                if (!f(x)) continue;

                x.Children = sub;
                rs.Add(x);
            }

            return rs;
        }

        public static bool Any<T>(this T @this, Func<T, bool> f) where T : ITree<T>
            => (@this.Parent?.Any(f) ?? false) || f(@this);
    }
}
