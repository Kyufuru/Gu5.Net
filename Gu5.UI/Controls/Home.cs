using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gu5.Net.Winforms.UI.Controls
{
    public partial class Home : UserControl
    {
        private void HdBtMuClick()
        {

        }

        private void HdBtMuToggle(bool d)
        {
            Tip.SetTip(BtMu, d ? "收起" : "展开");

            if (d)
            {
                Mu.Collapsed = false;
                Spl.IsSplitterFixed = false;
                Spl.SplitterDistance = 300;
            }
            else
            {
                Mu.Collapsed = true;
                Spl.IsSplitterFixed = true;
                Spl.SplitterDistance = 80;
            }
        }

        public Home() { InitializeComponent(); }
        private void BtMu_Click(object sender, EventArgs e) => HdBtMuClick();
        private void BtMu_ToggleChanged(object sender, AntdUI.BoolEventArgs e) => HdBtMuToggle(e.Value);
    }
}
