namespace Gu5.UI.Demos
{
    partial class GroupDemo
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
            this.group1 = new Gu5.UI.Group();
            this.button1 = new Gu5.UI.Button();
            this.button2 = new Gu5.UI.Button();
            this.button3 = new Gu5.UI.Button();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group1
            // 
            this.group1.Back = System.Drawing.Color.Transparent;
            this.group1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.group1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.group1.BorderWidth = 1F;
            this.group1.Controls.Add(this.button3);
            this.group1.Controls.Add(this.button2);
            this.group1.Controls.Add(this.button1);
            this.group1.Location = new System.Drawing.Point(49, 152);
            this.group1.Name = "group1";
            this.group1.Radius = 0;
            this.group1.Size = new System.Drawing.Size(243, 121);
            this.group1.TabIndex = 0;
            this.group1.Text = "group1";
            // 
            // button1
            // 
            this.button1.BorderWidth = 1F;
            this.button1.ControlSize = null;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.button1.IconType = null;
            this.button1.JoinMode = AntdUI.TJoinMode.Left;
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 119);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Type = null;
            // 
            // button2
            // 
            this.button2.BorderWidth = 1F;
            this.button2.ControlSize = null;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.button2.IconType = null;
            this.button2.JoinMode = AntdUI.TJoinMode.LR;
            this.button2.Location = new System.Drawing.Point(81, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 119);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.Type = null;
            // 
            // button3
            // 
            this.button3.BorderWidth = 1F;
            this.button3.ControlSize = null;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.button3.IconType = null;
            this.button3.JoinMode = AntdUI.TJoinMode.Right;
            this.button3.Location = new System.Drawing.Point(161, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 119);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.Type = null;
            // 
            // GroupDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group1);
            this.Name = "GroupDemo";
            this.Size = new System.Drawing.Size(459, 344);
            this.group1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Group group1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}
