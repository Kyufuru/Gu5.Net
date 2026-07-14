using System.ComponentModel;
using System.ComponentModel.Design;

using AntdUI;

using Gu5.Core.Reflections;
using Gu5.UI.Designers;
using Gu5.UI.Enums;

namespace Gu5.UI
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [Designer(typeof(FormItemDesigner))]
    public partial class FormItem : UserControl
    {
        /// <summary>
        /// 初始化
        /// </summary>
        private bool _init = false;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AntdUI.Panel Panel => P;

        [Category("Gu5_外观")]
        [Description("文本")]
        public string? Label
        {
            get => LName.Text;
            set => LName.Text = value;
        }

        [Category("Gu5_外观")]
        [Description("消息")]
        public string? Message
        {
            get => LText.Text;
            set => LText.Text = value;
        }

        [Category("Gu5_外观")]
        [Description("方向")]
        public GroupWay Direction
        {
            get => G.Direction;
            set => G.Direction = value;
        }

        [Category("Gu5_行为")]
        [Description("验证中")]
        public new event CancelEventHandler? Validating;

        [Category("Gu5_行为")]
        [Description("已验证成功")]
        public new event EventHandler? Validated;

        /// <summary>
        /// 显示错误消息
        /// </summary>
        public void ShowValid(string d)
        {
            Message = d;
            foreach (var x in P.Controls)
                x.SetValue("TType", TType.Error);
            LText.Type = TTypeMini.Error;
        }

        public FormItem() 
        {
            _init = true;
            InitializeComponent();
            _init = false;
            LText.ForeColor = Color.Transparent;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is null) return;
            if (ReferenceEquals(e.Control, P)) return;
            if (P.Controls.Contains(e.Control)) return;
            if (_init) return;

            BeginInvoke(() =>
            {
                if (e.Control is null) return;
                if (e.Control.Parent != this) return;

                e.Control.Dock = DockStyle.Fill;
                P.Controls.Add(e.Control);

                Validating += Inner_Validating;
                Validated += Inner_Validated;
            });
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e.Control is null) return;

            BeginInvoke(() =>
            {
                if (e.Control is null) return;
                if (e.Control.Parent != this) return;
                
                Validating -= Inner_Validating;
                Validated -= Inner_Validated;

                P.Controls.Remove(e.Control);
            });

            base.OnControlRemoved(e);
        }

        private void Inner_Validating(object? sender, CancelEventArgs e)
        {
            if (!e.Cancel) return;

            foreach (var x in P.Controls)
                x.SetValue("TType", TType.Error);
            LText.Type = TTypeMini.Error;
        }

        private void Inner_Validated(object? sender, EventArgs e)
        {
            LText.ForeColor = Color.Transparent;
            foreach (var x in P.Controls)
                x.SetValue("TType", TType.None);
        }
    }
}
