namespace Gu5.UI
{
    partial class FormItem
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
            this.G = new Gu5.UI.Group();
            this.GR = new Gu5.UI.Group();
            this.LText = new Gu5.UI.Label();
            this.P = new AntdUI.Panel();
            this.LName = new Gu5.UI.Label();
            ((System.ComponentModel.ISupportInitialize)(this.G)).BeginInit();
            this.G.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GR)).BeginInit();
            this.GR.SuspendLayout();
            this.SuspendLayout();
            // 
            // G
            // 
            this.G.Back = System.Drawing.Color.Transparent;
            this.G.BackColor = System.Drawing.Color.White;
            this.G.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.G.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.G.BorderWidth = 1F;
            this.G.Controls.Add(this.GR);
            this.G.Controls.Add(this.LName);
            this.G.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G.Location = new System.Drawing.Point(0, 0);
            this.G.Name = "G";
            this.G.Radius = 0;
            this.G.Size = new System.Drawing.Size(300, 60);
            this.G.TabIndex = 0;
            this.G.Text = "group1";
            // 
            // GR
            // 
            this.GR.Back = System.Drawing.Color.Transparent;
            this.GR.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GR.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.GR.BorderWidth = 1F;
            this.GR.Controls.Add(this.LText);
            this.GR.Controls.Add(this.P);
            this.GR.Direction = Gu5.UI.Enums.GroupWay.Vertical;
            this.GR.Dock = System.Windows.Forms.DockStyle.Left;
            this.GR.Location = new System.Drawing.Point(76, 1);
            this.GR.Name = "GR";
            this.GR.Radius = 0;
            this.GR.Size = new System.Drawing.Size(223, 58);
            this.GR.TabIndex = 1;
            this.GR.Text = "group2";
            // 
            // LText
            // 
            this.LText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LText.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LText.ForeColor = System.Drawing.Color.Firebrick;
            this.LText.Location = new System.Drawing.Point(1, 41);
            this.LText.Name = "LText";
            this.LText.Size = new System.Drawing.Size(221, 20);
            this.LText.TabIndex = 1;
            this.LText.Text = "验证失败";
            this.LText.Type = AntdUI.TTypeMini.Error;
            // 
            // P
            // 
            this.P.Back = System.Drawing.Color.Transparent;
            this.P.BackColor = System.Drawing.Color.Transparent;
            this.P.Dock = System.Windows.Forms.DockStyle.Top;
            this.P.Location = new System.Drawing.Point(1, 1);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(221, 40);
            this.P.TabIndex = 0;
            this.P.Text = "panel1";
            // 
            // LName
            // 
            this.LName.Dock = System.Windows.Forms.DockStyle.Left;
            this.LName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LName.Location = new System.Drawing.Point(1, 1);
            this.LName.Name = "LName";
            this.LName.Padding = new System.Windows.Forms.Padding(0, 0, 5, 20);
            this.LName.Size = new System.Drawing.Size(75, 58);
            this.LName.TabIndex = 0;
            this.LName.Text = "[名称]";
            this.LName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LName.Type = AntdUI.TTypeMini.Default;
            // 
            // FormItem
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.G);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormItem";
            this.Size = new System.Drawing.Size(300, 60);
            ((System.ComponentModel.ISupportInitialize)(this.G)).EndInit();
            this.G.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GR)).EndInit();
            this.GR.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Group G;
        private Group GR;
        private Label LName;
        private Label LText;
        private AntdUI.Panel P;
    }
}
