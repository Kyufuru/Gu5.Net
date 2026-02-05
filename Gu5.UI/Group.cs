
using System.ComponentModel;
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
    public class Group : AntdUI.Panel
    {
        private GroupWay _direction = GroupWay.Horizontal;


        [Category("布局")]
        [Description("排列方向")]
        [DefaultValue(GroupWay.Horizontal)]
        public GroupWay Direction 
        { 
            get => _direction; 
            set
            {
                if (_direction != value)
                    ChangeDirection(value);
                _direction = value;
            }
        }

        private void SetSize(bool isH, IEnumerable<AntdUI.Button> l, AntdUI.Button b)
        {
            var w = isH ? l.Sum(x => x.Width) + b.Margin.Right : b.Width;
            var h = isH ? b.Height : l.Sum(x => x.Height) + b.Margin.Top;
            Size = new Size(w, h);
        }


        private AntdUI.Button? _lastBt;
        private void AddJoin(Control? d)
        {
            if (d is not AntdUI.Button b) return;

            var l = Controls.OfType<AntdUI.Button>();
            if (!l.Any()) return;

            var isH = _direction == GroupWay.Horizontal;

            SetSize(isH, l, b);

            var cnt = l.Count();
            
            var bj = isH ? TJoinMode.Right : TJoinMode.Bottom;
            var nj0 = isH ? TJoinMode.Left : TJoinMode.Top;
            var nj = isH ? TJoinMode.LR : TJoinMode.TB;

            b.Dock = isH ? DockStyle.Left : DockStyle.Top;
            b.JoinMode = cnt == 1 ? TJoinMode.None : bj;

            _lastBt?.Also(x => x.JoinMode = cnt == 2 ? nj0 : nj);
            _lastBt = b;
        }

        private void RemoveJoin()
        {
            var l = Controls.OfType<AntdUI.Button>();
            if (!l.Any()) return;

            var b = l.FirstOrDefault();
            if (b is null) return;

            var isH = _direction == GroupWay.Horizontal;

            SetSize(isH, l, b);

            var cnt = l.Count();
            var bj = isH ? TJoinMode.Right : TJoinMode.Bottom;
            b.JoinMode = cnt == 1 ? TJoinMode.None : bj;
        }

        private void ChangeDirection(GroupWay d)
        {
            var isH = d == GroupWay.Horizontal;
            var l = Controls.OfType<AntdUI.Button>();
            if (!l.Any()) return;

            var bd = isH ? DockStyle.Left : DockStyle.Top;
            var bj = isH ? TJoinMode.LR : TJoinMode.TB;
            var bj0 = isH ? TJoinMode.Left : TJoinMode.Top;
            var bj1 = isH ? TJoinMode.Right : TJoinMode.Bottom;

            l.Reverse().ForEach((x, i) =>
            {
                x.Dock = bd;

                if (i == 0) x.JoinMode = bj0;
                else if (i == l.Count() - 1) x.JoinMode = bj1;
                else x.JoinMode = bj;
            });

            var b = l.FirstOrDefault();
            if (b is null) return;

            SetSize(isH, l, b);
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

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            AddJoin(e.Control);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            RemoveJoin();
        }
    }
}
