using System.ComponentModel;

namespace Gu5.Net.Winforms.UI.Controls.Buttons
{
    public partial class ButtonCreate : AntdUI.Button
    {
        public ButtonCreate()
        {
            InitializeComponent();

            Text = "创建";
            Size = new(90, 40);
            Font = new("Microsoft YaHei UI", 10F);
            BorderWidth = 1;
        }

        public ButtonCreate(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
