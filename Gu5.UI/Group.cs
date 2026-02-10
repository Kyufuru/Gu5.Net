
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;

using AntdUI;

using Gu5.Core;
using Gu5.UI.Enums;

namespace Gu5.UI
{
    /// <summary>
    /// 控件组
    /// </summary>
    [Designer(typeof(ParentControlDesigner))]
    public class Group : AntdUI.Panel, ISupportInitialize
    {
        private GroupWay _direction = GroupWay.Horizontal;
        private Control? _last;
        private bool _reverse = false;
        private int _cnt = 0;

        [Category("布局")]
        [Description("排列方向")]
        [DefaultValue(GroupWay.Horizontal)]
        public GroupWay Direction 
        { 
            get => _direction; 
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    ChangeDirection();
                }
            }
        }

        void ISupportInitialize.BeginInit()
        {
            _reverse = true;
        }

        void ISupportInitialize.EndInit()
        {
            _reverse = false;
        }

        /// <summary>
        /// 获取真实尺寸
        /// </summary>
        /// <param name="c">控件</param>
        /// <param name="isH">方向</param>
        /// <returns></returns>
        private static int GetRealSize(Control c, bool isH)
        {
            int len = isH ? c.Width : c.Height;
            if (len > 0) return len;
            
            var p = c.GetPreferredSize(Size.Empty);
            len = isH ? p.Width : p.Height;
            if (len > 0) return len;

            len = isH ? c.MinimumSize.Width : c.MinimumSize.Height;
            if (len > 0) return len;
            
            return isH ? 80 : 32;
        }

        private static bool CanJoin(Control c) =>
            c.GetType().GetProperty("JoinMode") is not null;

        private static void Join(Control? c, TJoinMode mode)
        {
            if (c == null) return;
            var prop = c.GetType().GetProperty("JoinMode");
            if (prop != null && prop.CanWrite)
                prop.SetValue(c, mode);
        }

        private void SetSize(bool isH, Control d)
        {
            var l = Controls.OfType<Control>();
            var s = l.Sum(x => GetRealSize(x, isH));
            var w = isH ? s + d.Margin.Right : Size.Width;
            var h = isH ? Size.Height : s + d.Margin.Top;

            Size = new Size(w, h);
        }

        private void AddJoin(Control? d)
        {
            if (d is null) return;

            var isH = _direction == GroupWay.Horizontal;
            d.Dock = isH ? DockStyle.Left : DockStyle.Top;

            var l = Controls.OfType<Control>().Where(CanJoin);
            if (!l.Any()) return;

            SetSize(isH, d);
            
            var rb = isH ? TJoinMode.Right : TJoinMode.Bottom;
            var lt = isH ? TJoinMode.Left : TJoinMode.Top;
            var md = isH ? TJoinMode.LR : TJoinMode.TB;

            if (_reverse) (rb, lt) = (lt, rb);

            if (!CanJoin(d)) return;
            Join(d, _cnt == 1 ? TJoinMode.None : rb);

            _last?.Also(x => Join(x, _cnt == 2 ? lt : md));
            _last = d;
        }

        private void RemoveJoin()
        {
            var l = Controls.OfType<Control>().Where(CanJoin);
            if (!l.Any()) return;

            var d = l.FirstOrDefault();
            if (d is null || !CanJoin(d)) return;
            var isH = _direction == GroupWay.Horizontal;

            SetSize(isH, d);
            
            var bj = isH ? TJoinMode.Right : TJoinMode.Bottom;
            Join(d, _cnt == 1 ? TJoinMode.None : bj);
        }

        private void ChangeDirection()
        {
            SuspendLayout();

            var l = Controls.OfType<Control>().ToList();
            
            _last = null;
            if (l.Count > 0)
            {
                var b = l[0];
                foreach (var c in l) c.Dock = DockStyle.None;

                if (_direction == GroupWay.Horizontal)
                    Height = b.Height + b.Margin.Vertical;
                else  Width = b.Width + b.Margin.Horizontal;
            }

            _reverse = true;
            Controls.Clear();
            Controls.AddRange([.. l]);
            _reverse = false;

            ResumeLayout(true);
        }

        public Group()
        {
            Back = Color.Transparent;
            Size = new(80, 40);
            Radius = 0;
        }

        private bool IsDesigner =>  DesignMode 
            || LicenseManager.UsageMode == LicenseUsageMode.Designtime 
            || Process.GetCurrentProcess().ProcessName
                .Equals("devenv", StringComparison.OrdinalIgnoreCase);
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (IsDesigner)
            {
                BorderWidth = 1;
                BorderColor = "#AAA".ToColor();
                BorderStyle = DashStyle.Dot;
            }
            else BorderWidth = 0;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            _cnt = _reverse ? _cnt + 1 : Controls.Count;
            AddJoin(e.Control);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            RemoveJoin();

            if (e.Control is null || !CanJoin(e.Control)) return;

            _cnt--;
            _last = _cnt == 0 ? null 
                : Controls.OfType<Control>()
                .Reverse().At(_cnt - 1);
        }
    }
}
