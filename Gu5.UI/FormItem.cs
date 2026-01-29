using System.ComponentModel;

namespace Gu5.UI
{
    public partial class FormItem : UserControl
    {
        public string? LabelText 
        { 
            get => Lb.Text; 
            set => Lb.Text = value;
        }


        public DockStyle LabelAlign 
        { 
            get => Lb.Dock; 
            set
            {
                if (value == DockStyle.Bottom ||
                    value == DockStyle.Right ||
                    value == DockStyle.None) return;

                Lb.Dock = value;

                if (value == DockStyle.Top)
                    Lb.TextAlign = ContentAlignment.BottomLeft;
                if (value == DockStyle.Left)
                    Lb.TextAlign = ContentAlignment.MiddleRight;
            }
        }

        public FormItem() { InitializeComponent(); }
    }
}
