namespace Gu5.Net.Winforms.UI.Controls
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            P = new AntdUI.Panel();
            PL = new AntdUI.Panel();
            PLM = new AntdUI.Panel();
            LbDes = new AntdUI.Label();
            Dv = new AntdUI.Divider();
            LbVer = new AntdUI.Label();
            PLT = new AntdUI.Panel();
            LbTit = new AntdUI.Label();
            Ic = new PictureBox();
            Ph2 = new AntdUI.PageHeader();
            PR = new AntdUI.Panel();
            PRM = new AntdUI.Panel();
            PFm = new AntdUI.Panel();
            BtOk = new AntdUI.Button();
            PRmb = new AntdUI.Panel();
            Ck = new AntdUI.Checkbox();
            IpPwd = new AntdUI.Input();
            IpAcc = new AntdUI.Input();
            LbR = new AntdUI.Label();
            Ph = new AntdUI.PageHeader();
            P.SuspendLayout();
            PL.SuspendLayout();
            PLM.SuspendLayout();
            PLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Ic).BeginInit();
            PR.SuspendLayout();
            PRM.SuspendLayout();
            PFm.SuspendLayout();
            PRmb.SuspendLayout();
            SuspendLayout();
            // 
            // P
            // 
            P.Controls.Add(PL);
            P.Controls.Add(PR);
            P.Dock = DockStyle.Fill;
            P.Location = new Point(0, 0);
            P.Name = "P";
            P.Size = new Size(700, 400);
            P.TabIndex = 0;
            P.Text = "panel1";
            // 
            // PL
            // 
            PL.BackExtend = "#2a3451,#151a28,#354165";
            PL.Controls.Add(PLM);
            PL.Controls.Add(Ph2);
            PL.Dock = DockStyle.Fill;
            PL.Location = new Point(0, 0);
            PL.Name = "PL";
            PL.Radius = 0;
            PL.RadiusAlign = AntdUI.TAlignRound.Left;
            PL.Size = new Size(398, 400);
            PL.TabIndex = 2;
            PL.Text = "panel1";
            // 
            // PLM
            // 
            PLM.Back = Color.Transparent;
            PLM.BackgroundImageLayout = AntdUI.TFit.None;
            PLM.Controls.Add(LbDes);
            PLM.Controls.Add(Dv);
            PLM.Controls.Add(LbVer);
            PLM.Controls.Add(PLT);
            PLM.Dock = DockStyle.Fill;
            PLM.Location = new Point(0, 30);
            PLM.Name = "PLM";
            PLM.Padding = new Padding(40, 10, 40, 35);
            PLM.RadiusAlign = AntdUI.TAlignRound.Right;
            PLM.Size = new Size(398, 370);
            PLM.TabIndex = 6;
            PLM.Text = "panel1";
            // 
            // LbDes
            // 
            LbDes.Dock = DockStyle.Fill;
            LbDes.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 1, true);
            LbDes.ForeColor = SystemColors.ButtonFace;
            LbDes.Location = new Point(40, 44);
            LbDes.Name = "LbDes";
            LbDes.Padding = new Padding(0, 20, 0, 20);
            LbDes.Size = new Size(318, 251);
            LbDes.TabIndex = 3;
            LbDes.Text = "[副标题]";
            LbDes.TextAlign = ContentAlignment.TopLeft;
            // 
            // Dv
            // 
            Dv.ColorScheme = AntdUI.TAMode.Dark;
            Dv.ColorSplit = Color.FromArgb(105, 129, 202);
            Dv.Dock = DockStyle.Bottom;
            Dv.Location = new Point(40, 295);
            Dv.Name = "Dv";
            Dv.OrientationMargin = 0F;
            Dv.Size = new Size(318, 5);
            Dv.TabIndex = 4;
            Dv.Text = "";
            Dv.Thickness = 0.5F;
            // 
            // LbVer
            // 
            LbVer.Dock = DockStyle.Bottom;
            LbVer.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 1, true);
            LbVer.ForeColor = SystemColors.ButtonFace;
            LbVer.Location = new Point(40, 300);
            LbVer.Name = "LbVer";
            LbVer.Size = new Size(318, 35);
            LbVer.TabIndex = 5;
            LbVer.Text = "[版本号]";
            LbVer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PLT
            // 
            PLT.Back = Color.Transparent;
            PLT.Controls.Add(LbTit);
            PLT.Controls.Add(Ic);
            PLT.Dock = DockStyle.Top;
            PLT.Location = new Point(40, 10);
            PLT.Name = "PLT";
            PLT.RadiusAlign = AntdUI.TAlignRound.Right;
            PLT.Size = new Size(318, 34);
            PLT.TabIndex = 7;
            PLT.Text = "panel1";
            // 
            // LbTit
            // 
            LbTit.Dock = DockStyle.Fill;
            LbTit.Font = new Font("Microsoft YaHei UI", 17F, FontStyle.Bold);
            LbTit.ForeColor = Color.WhiteSmoke;
            LbTit.Location = new Point(32, 0);
            LbTit.Name = "LbTit";
            LbTit.Padding = new Padding(5, 1, 5, 0);
            LbTit.Size = new Size(286, 34);
            LbTit.TabIndex = 0;
            LbTit.Text = "[标题]";
            // 
            // Ic
            // 
            Ic.Dock = DockStyle.Left;
            Ic.Image = (Image)resources.GetObject("Ic.Image");
            Ic.Location = new Point(0, 0);
            Ic.Name = "Ic";
            Ic.Size = new Size(32, 34);
            Ic.SizeMode = PictureBoxSizeMode.Zoom;
            Ic.TabIndex = 1;
            Ic.TabStop = false;
            // 
            // Ph2
            // 
            Ph2.Dock = DockStyle.Top;
            Ph2.Location = new Point(0, 0);
            Ph2.MaximizeBox = false;
            Ph2.MDI = true;
            Ph2.MinimizeBox = false;
            Ph2.Name = "Ph2";
            Ph2.Size = new Size(398, 30);
            Ph2.TabIndex = 5;
            Ph2.Text = " ";
            Ph2.UseForeColorDrawIcons = true;
            // 
            // PR
            // 
            PR.Controls.Add(PRM);
            PR.Controls.Add(Ph);
            PR.Dock = DockStyle.Right;
            PR.Location = new Point(398, 0);
            PR.Name = "PR";
            PR.Radius = 0;
            PR.Size = new Size(302, 400);
            PR.TabIndex = 4;
            PR.Text = "panel1";
            // 
            // PRM
            // 
            PRM.Controls.Add(PFm);
            PRM.Controls.Add(LbR);
            PRM.Dock = DockStyle.Fill;
            PRM.Location = new Point(0, 30);
            PRM.Name = "PRM";
            PRM.Padding = new Padding(40, 10, 40, 35);
            PRM.RadiusAlign = AntdUI.TAlignRound.Right;
            PRM.Size = new Size(302, 370);
            PRM.TabIndex = 1;
            PRM.Text = "panel1";
            // 
            // PFm
            // 
            PFm.Controls.Add(BtOk);
            PFm.Controls.Add(PRmb);
            PFm.Controls.Add(IpPwd);
            PFm.Controls.Add(IpAcc);
            PFm.Dock = DockStyle.Top;
            PFm.Location = new Point(40, 44);
            PFm.Name = "PFm";
            PFm.Padding = new Padding(0, 10, 0, 0);
            PFm.Size = new Size(222, 280);
            PFm.TabIndex = 2;
            PFm.Text = "panel1";
            // 
            // BtOk
            // 
            BtOk.Dock = DockStyle.Bottom;
            BtOk.Font = new Font("Microsoft YaHei UI", 11F);
            BtOk.IconGap = 0.5F;
            BtOk.IconSvg = "LoginOutlined";
            BtOk.Location = new Point(0, 240);
            BtOk.Name = "BtOk";
            BtOk.Radius = 3;
            BtOk.Size = new Size(222, 40);
            BtOk.TabIndex = 4;
            BtOk.Text = "登 录";
            BtOk.Type = AntdUI.TTypeMini.Primary;
            BtOk.Click += BtOk_Click;
            // 
            // PRmb
            // 
            PRmb.Controls.Add(Ck);
            PRmb.Dock = DockStyle.Top;
            PRmb.Location = new Point(0, 90);
            PRmb.Name = "PRmb";
            PRmb.Size = new Size(222, 30);
            PRmb.TabIndex = 3;
            PRmb.Text = "panel1";
            // 
            // Ck
            // 
            Ck.Dock = DockStyle.Fill;
            Ck.Font = new Font("Microsoft YaHei UI", 10F);
            Ck.Location = new Point(0, 0);
            Ck.Name = "Ck";
            Ck.Size = new Size(222, 30);
            Ck.TabIndex = 0;
            Ck.Text = "记住用户名";
            // 
            // IpPwd
            // 
            IpPwd.AllowClear = true;
            IpPwd.Dock = DockStyle.Top;
            IpPwd.Font = new Font("Microsoft YaHei UI", 10F);
            IpPwd.IconGap = 0.5F;
            IpPwd.Location = new Point(0, 50);
            IpPwd.Name = "IpPwd";
            IpPwd.PlaceholderColor = Color.FromArgb(170, 170, 170);
            IpPwd.PlaceholderText = "密码";
            IpPwd.PrefixFore = Color.FromArgb(68, 68, 68);
            IpPwd.PrefixSvg = "LockOutlined";
            IpPwd.Radius = 3;
            IpPwd.Size = new Size(222, 40);
            IpPwd.TabIndex = 1;
            IpPwd.Tag = "密码";
            IpPwd.UseSystemPasswordChar = true;
            IpPwd.KeyUp += ULogin_KeyUp;
            IpPwd.Validating += IpPwd_Validating;
            // 
            // IpAcc
            // 
            IpAcc.AllowClear = true;
            IpAcc.Dock = DockStyle.Top;
            IpAcc.Font = new Font("Microsoft YaHei UI", 10F);
            IpAcc.IconGap = 0.5F;
            IpAcc.Location = new Point(0, 10);
            IpAcc.Name = "IpAcc";
            IpAcc.PlaceholderColor = Color.FromArgb(170, 170, 170);
            IpAcc.PlaceholderText = "用户名";
            IpAcc.PrefixFore = Color.FromArgb(68, 68, 68);
            IpAcc.PrefixSvg = "UserOutlined";
            IpAcc.Radius = 3;
            IpAcc.Size = new Size(222, 40);
            IpAcc.TabIndex = 0;
            IpAcc.Tag = "用户名";
            IpAcc.KeyUp += ULogin_KeyUp;
            IpAcc.Validating += IpAcc_Validating;
            // 
            // LbR
            // 
            LbR.Dock = DockStyle.Top;
            LbR.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold);
            LbR.ForeColor = Color.FromArgb(68, 68, 68);
            LbR.Location = new Point(40, 10);
            LbR.Name = "LbR";
            LbR.Padding = new Padding(5, 0, 5, 0);
            LbR.Size = new Size(222, 34);
            LbR.TabIndex = 1;
            LbR.Text = "用户登录";
            // 
            // Ph
            // 
            Ph.Dock = DockStyle.Top;
            Ph.Location = new Point(0, 0);
            Ph.MaximizeBox = false;
            Ph.MDI = true;
            Ph.MinimizeBox = false;
            Ph.Name = "Ph";
            Ph.ShowButton = true;
            Ph.Size = new Size(302, 30);
            Ph.TabIndex = 3;
            Ph.Text = " ";
            Ph.UseForeColorDrawIcons = true;
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.Transparent;
            Controls.Add(P);
            Name = "Login";
            Size = new Size(700, 400);
            KeyUp += ULogin_KeyUp;
            P.ResumeLayout(false);
            PL.ResumeLayout(false);
            PLM.ResumeLayout(false);
            PLT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Ic).EndInit();
            PR.ResumeLayout(false);
            PRM.ResumeLayout(false);
            PFm.ResumeLayout(false);
            PRmb.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel P;
        private AntdUI.Panel PRM;
        private AntdUI.Panel PL;
        private AntdUI.Label LbTit;
        private AntdUI.Label LbDes;
        private AntdUI.Divider Dv;
        private AntdUI.Label LbVer;
        private AntdUI.Label LbR;
        private AntdUI.Panel PFm;
        private AntdUI.Input IpAcc;
        private AntdUI.Input IpPwd;
        private AntdUI.Checkbox Ck;
        private AntdUI.Button BtOk;
        private AntdUI.Panel PRmb;
        private AntdUI.Panel PR;
        private AntdUI.PageHeader Ph;
        private PictureBox Ic;
        private AntdUI.Panel PLM;
        private AntdUI.PageHeader Ph2;
        private AntdUI.Panel PLT;
    }
}
