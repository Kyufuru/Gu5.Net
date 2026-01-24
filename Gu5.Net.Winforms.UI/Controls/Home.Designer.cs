namespace Gu5.Net.Winforms.UI.Controls
{
    partial class Home
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            P = new AntdUI.Panel();
            PM = new AntdUI.Panel();
            Spl = new AntdUI.Splitter();
            Mu = new AntdUI.Menu();
            PH = new AntdUI.PageHeader();
            BtMu = new AntdUI.Button();
            Tip = new AntdUI.TooltipComponent();
            P.SuspendLayout();
            PM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Spl).BeginInit();
            Spl.Panel1.SuspendLayout();
            Spl.SuspendLayout();
            PH.SuspendLayout();
            SuspendLayout();
            // 
            // P
            // 
            P.Controls.Add(PM);
            P.Controls.Add(PH);
            P.Dock = DockStyle.Fill;
            P.Location = new Point(0, 0);
            P.Name = "P";
            P.Size = new Size(1200, 700);
            P.TabIndex = 0;
            P.Text = "panel1";
            // 
            // PM
            // 
            PM.Back = Color.WhiteSmoke;
            PM.Controls.Add(Spl);
            PM.Dock = DockStyle.Fill;
            PM.Location = new Point(0, 40);
            PM.Name = "PM";
            PM.Size = new Size(1200, 660);
            PM.TabIndex = 1;
            PM.Text = "panel2";
            // 
            // Spl
            // 
            Spl.Dock = DockStyle.Fill;
            Spl.Location = new Point(0, 0);
            Spl.Name = "Spl";
            // 
            // Spl.Panel1
            // 
            Spl.Panel1.Controls.Add(Mu);
            Spl.Size = new Size(1200, 660);
            Spl.SplitterDistance = 35;
            Spl.TabIndex = 1;
            // 
            // Mu
            // 
            Mu.BackColor = Color.White;
            Mu.Collapsed = true;
            Mu.Dock = DockStyle.Fill;
            Mu.Indent = true;
            menuItem1.IconSvg = "DeleteOutlined";
            menuItem2.IconSvg = "DeleteOutlined";
            menuItem2.Text = "222";
            menuItem1.Sub.Add(menuItem2);
            menuItem1.Text = "111";
            Mu.Items.Add(menuItem1);
            Mu.Location = new Point(0, 0);
            Mu.Name = "Mu";
            Mu.ScrollBarBlock = true;
            Mu.ShowSubBack = true;
            Mu.Size = new Size(35, 660);
            Mu.TabIndex = 0;
            Mu.Text = "menu1";
            Mu.Trigger = AntdUI.Trigger.Click;
            // 
            // PH
            // 
            PH.Controls.Add(BtMu);
            PH.Dock = DockStyle.Top;
            PH.Gap = 0;
            PH.Location = new Point(0, 0);
            PH.Name = "PH";
            PH.ShowButton = true;
            PH.Size = new Size(1200, 40);
            PH.TabIndex = 0;
            PH.Text = " ";
            // 
            // BtMu
            // 
            BtMu.AutoToggle = true;
            BtMu.Dock = DockStyle.Left;
            BtMu.IconRatio = 1F;
            BtMu.IconSvg = "MenuUnfoldOutlined";
            BtMu.Location = new Point(4, 0);
            BtMu.Name = "BtMu";
            BtMu.Padding = new Padding(2, 7, 2, 7);
            BtMu.Size = new Size(30, 40);
            BtMu.TabIndex = 0;
            Tip.SetTip(BtMu, "展开");
            BtMu.ToggleIconSvg = "MenuFoldOutlined";
            BtMu.WaveSize = 0;
            BtMu.ToggleChanged += BtMu_ToggleChanged;
            BtMu.Click += BtMu_Click;
            // 
            // Tip
            // 
            Tip.ArrowAlign = AntdUI.TAlign.Right;
            Tip.Delay = 700;
            // 
            // Home
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(P);
            Name = "Home";
            Size = new Size(1200, 700);
            P.ResumeLayout(false);
            PM.ResumeLayout(false);
            Spl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Spl).EndInit();
            Spl.ResumeLayout(false);
            PH.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel P;
        private AntdUI.PageHeader PH;
        private AntdUI.Panel PM;
        private AntdUI.Button BtMu;
        private AntdUI.TooltipComponent Tip;
        private AntdUI.Menu Mu;
        private AntdUI.Splitter Spl;
    }
}
