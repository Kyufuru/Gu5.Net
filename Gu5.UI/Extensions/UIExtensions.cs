using System.Drawing.Text;

using AntdUI;

using Gu5.Net.Core;

namespace Gu5.Net.Winforms.UI.Extensions
{
    public static class UIExtensions
    {
        /// <summary>
        /// 使用初始配置
        /// </summary>
        public static void UseUI(this App _)
        {
            
        }

        public static Form GetForm(this Control @this)
        {
            var f = @this.FindForm();
            if (f != null) return f;

            var p = @this;
            while (p != null)
            {
                if (p is Form pf) return pf;
                p = p.Parent;
            }

            if (@this is ToolStrip ts &&
                ts.FindForm() is Form tf) return tf;

            if (Application.OpenForms.Count > 0)
            {
                var af = Form.ActiveForm;
                if (af != null) return af;
            }

            return Application.OpenForms[0]!;
        }

        public static AntdUI.BaseCollection LClear(this AntdUI.BaseCollection @this)
        {
            @this.Clear();
            return @this;
        }
        public static void AddRange<T>(this AntdUI.BaseCollection @this,
            IEnumerable<T> val) => @this.AddRange([.. val.OfType<object>()]);

        public static SelectItem[] AsOptions<T, V>(this IEnumerable<T> @this,
            Func<T, string> k, Func<T, V> v, string? def = null)
        {
            var rs = new List<SelectItem>();
            if (def is not null) rs.Add(new(def, string.Empty));
            @this.ForEach(x =>
            {
                if (x is null) return;
                rs.Add(new(k(x), v(x)!));
            });
            return [.. rs];
        }

        public static SelectItem[] AsOptions<T>(this IEnumerable<T> @this,
            Func<T, string> k, string? def = null) =>
            @this.AsOptions(k, x => x, def);
    }
}
