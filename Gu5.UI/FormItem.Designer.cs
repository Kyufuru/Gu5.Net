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
            Lb = new AntdUI.Label();
            PM = new AntdUI.Panel();
            P = new AntdUI.Panel();
            P.SuspendLayout();
            SuspendLayout();
            // 
            // Lb
            // 
            Lb.BackColor = Color.Transparent;
            Lb.Dock = DockStyle.Left;
            Lb.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            Lb.Location = new Point(0, 0);
            Lb.Name = "Lb";
            Lb.Padding = new Padding(5);
            Lb.Size = new Size(100, 50);
            Lb.TabIndex = 0;
            Lb.Text = "label";
            Lb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PM
            // 
            PM.Dock = DockStyle.Fill;
            PM.Location = new Point(100, 0);
            PM.Name = "PM";
            PM.Size = new Size(200, 50);
            PM.TabIndex = 1;
            PM.Text = "panel1";
            // 
            // P
            // 
            P.Controls.Add(PM);
            P.Controls.Add(Lb);
            P.Dock = DockStyle.Fill;
            P.Location = new Point(0, 0);
            P.Name = "P";
            P.Size = new Size(300, 50);
            P.TabIndex = 2;
            P.Text = "panel1";
            // 
            // FormItem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(P);
            Name = "FormItem";
            Size = new Size(300, 50);
            P.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label Lb;
        private AntdUI.Panel PM;
        private AntdUI.Panel P;
    }
}
