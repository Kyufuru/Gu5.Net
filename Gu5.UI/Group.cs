
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;

using AntdUI;

using Gu5.Core;
using Gu5.UI.Models;

namespace Gu5.UI
{
    /// <summary>
    /// 控件组
    /// </summary>
    [Designer(typeof(ParentControlDesigner))]
    public class Group : AntdUI.Panel
    {
        private bool _isJoining = false;

        private static void Join(GroupMap d, string s)
        {
            var t = d.Prop?.PropertyType;

            if (t is null) return;
            if (!t.IsEnum) return;

            try
            {
                var v = Enum.Parse(t, s);
                d.Prop?.SetValue(d.Control, v);
            }
            catch { /* 忽略 */ }
        }

        private void SetStyle()
        {
            var l = Controls.OfType<Control>();
            var w = l.Sum(x => x?.Size.Width ?? 0);
            if (w > 0) Size = new(w + Padding.Horizontal, Size.Height);

            l.ForEach(x => x.Dock = DockStyle.Left);
        }

        private void SetJoin()
        {
            if (_isJoining) return;
            else _isJoining = true;


            try
            {
                SetStyle();

                var l = Controls
                    .OfType<Control>()
                    .Select(c => new GroupMap()
                    {
                        Control = c,
                        Prop = TypeDescriptor
                            .GetProperties(c)
                            .Find("JoinMode", false)
                    })
                    .Where(x => x.Prop != null)
                    .OrderBy(x => x.Control?.Left);

                var cnt = l.Count();
                l.ForEach((x, i) =>
                {
                    if (x.Control is null) return;
                    

                    var m = "None";
                    if (cnt > 1)
                    {
                        if (i == 0) m = "Left";
                        else if (i == cnt - 1) m = "Right";
                        else m = "LR";
                    }

                    Join(x, m);
                });
            }
            finally
            {
                _isJoining = false;
            }
        }

        public Group()
        {
            Back = Color.Transparent;
            Size = new(80, 40);
            Radius = 0;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (DesignMode)
            {
                BorderWidth = 1;
                BorderColor = "#AAA".ToColor();
                BorderStyle = DashStyle.Dot;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            SetJoin();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            SetJoin();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            SetJoin();
        }
    }
}
